using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CheckingContainerManager : MonoBehaviour
{
    public Material right, wrong, defaultMaterial;
    public GameObject container;
    private GameObject[] fakesArray;
    private int numTotal = 8;
    private int visible = 4;
    private int oneToShow = 8;
    int active;

    private void Awake()
    {
        if (GameObject.Find("PurpleJewelOriginal") != null)
        {
            Destroy(GameObject.Find("PurpleJewelOriginal"), 1.0f);
        }
        fakesArray = new GameObject[numTotal];
        for (int i = 0; i < numTotal; i++)
        {
            GameObject obj = GameObject.Find("FakePedestal" + i);
            if (i > 3)
            {
                obj.SetActive(false);
            }
            fakesArray[i] = obj;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RealGem"))
        {
            gameObject.GetComponent<MeshRenderer>().material = right;
            GameObject.Find("gatePurple").GetComponent<GateController>().isCompleted = true; // check if completed
        }
        else if (other.gameObject.CompareTag("Denial") || other.gameObject.CompareTag("Bargain") || other.gameObject.CompareTag("Depression") || other.gameObject.CompareTag("Acceptance") || other.gameObject.CompareTag("Anger"))
        {
            gameObject.GetComponent<MeshRenderer>().material = wrong;
            //StartCoroutine(InvokeCoroutine(other.gameObject));
            //StartCoroutine("LoadNext");
            StartCoroutine(LoadNext(other.gameObject));
        }
    }

    //IEnumerator InvokeCoroutine(GameObject other)
    //{
    //    yield return new WaitForSeconds(1);
    //    other.SetActive(false);
    //    container.GetComponent<MeshRenderer>().material = defaultMaterial;
    //    yield return null;

    //}

    private void OnTriggerExit(Collider other)
    {
        StopCoroutine("LoadNext");
        container.GetComponent<MeshRenderer>().material = defaultMaterial;
    }

    IEnumerator LoadNext(GameObject other) {
        yield return new WaitForSeconds(1);
        other.SetActive(false);
        container.GetComponent<MeshRenderer>().material = defaultMaterial;
        //GameObject lastElement = fakesArray[fakesArray.Length - 1];
        //lastElement.SetActive(true);
        fakesArray[visible].SetActive(true);
        //oneToShow--;
        visible++;
        //fakesArray = fakesArray.Take(fakesArray.Length - 1).ToArray();

        List<int> active = new List<int>();

        int index = 0;
        foreach (var fake in fakesArray) {
            if (fake.activeSelf) active.Add(index);
            ++index;
        }

        if (visible == 8 && active.Count == 1)
        {
            fakesArray[active[0]].transform.GetChild(2).tag = "RealGem";
            fakesArray[active[0]].transform.GetChild(2).GetComponent<MeshRenderer>().material = right;
        }
        else
        {
            int random = Random.Range(0, active.Count);
            //do
            //{
            //    random = Random.Range(0, visible);
            //} while (!fakesArray[random].activeSelf);

            for (int i = 0; i < visible; i++)
            {
                if (i == active[random])
                {
                    fakesArray[i].transform.GetChild(2).tag = "RealGem";
                    fakesArray[i].transform.GetChild(2).GetComponent<MeshRenderer>().material = right;

                }
                else
                {
                    fakesArray[i].transform.GetChild(2).tag = "Denial";
                    fakesArray[i].transform.GetChild(2).GetComponent<MeshRenderer>().material = defaultMaterial;
                }

            }
        }

    
        
        
        yield return null;
    }
}
