using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptanceManager : MonoBehaviour
{
    private bool denialCompleted;
    private bool angerCompleted;
    private bool bargainCompleted;
    private bool depressionCompleted;

    //public GameObject whiteJewel;

    public GateController purpleGate;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        denialCompleted = GameObject.Find("gatePurple").GetComponent<GateController>().isCompleted;
        angerCompleted = GameObject.Find("gateRed").GetComponent<GateController>().isCompleted;
        bargainCompleted = GameObject.Find("gateGreen").GetComponent<GateController>().isCompleted;
        depressionCompleted = GameObject.Find("gateBlue").GetComponent<GateController>().isCompleted;
        if (denialCompleted && angerCompleted && bargainCompleted && depressionCompleted)
        {
            gameObject.SetActive(true); // set white to active
            // transition to acceptance scene
        }
    }
}
