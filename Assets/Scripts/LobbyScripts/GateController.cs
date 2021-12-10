using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GateController : MonoBehaviour
{
    //public GameObject blueGate;
    //public GameObject redGate;
    //public GameObject yellowGate;
    //public GameObject whiteGate;
    //bool bActive;
    //bool rActive;
    //bool yActive;
    //bool wActive;
    public GameObject gate;
    bool active;
    public AudioSource openGate;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
        gate.SetActive(active);

        openGate = GetComponent<AudioSource>();

        //bActive = false;
        //rActive = false;
        //yActive = false;
        //wActive = false;

        //blueGate.SetActive(bActive);
        //redGate.SetActive(rActive);
        //yellowGate.SetActive(yActive);
        //whiteGate.SetActive(wActive);
    }

    public void activate(SelectEnterEventArgs args)
    {
        if (args.interactor.gameObject.CompareTag("Hand")){
            active = true;
            gate.SetActive(active);
            if (counter < 1)
            {
                openGate.Play();
                counter++;
            }
            

            //Debug.Log("active");
        }
        //Debug.Log("??");


        //bActive = true;
    }

    public void deactivate()
    {
        //active = false;
        //gate.SetActive(active);
        //bActive = false;
    }
}
