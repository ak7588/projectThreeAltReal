using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalManager : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = 350f;
    public Material gray;

    public Material passMaterial;
    //public GameObject gem;

    private void Awake()
    {
        if (GameObject.Find("BlueJewel") != null)
        {
            GameObject.Find("BlueJewel").transform.GetChild(0).GetComponent<MeshRenderer>().material = gray;


        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Pass"))
        {
            StartCoroutine(ShootTheCube(other.gameObject));

        }
        else
        {
            GetComponent<MeshRenderer>().material = passMaterial;
            GameObject.Find("gateBlue").GetComponent<GateController>().isCompleted = true; // check if completed
        }
    }

    IEnumerator ShootTheCube(GameObject other)
    {
        var rand = Random.onUnitSphere;
        rand.y = launchVelocity;
        other.GetComponent<Rigidbody>().AddForce(rand);
        yield return null;
    }
}
