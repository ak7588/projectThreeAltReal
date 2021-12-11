using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AcceptanceManager : MonoBehaviour
{

    public GateController purpleGate;
    public GateController redGate;
    public GateController greenGate;
    public GateController blueGate;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);
        gameObject.GetComponent<XRGrabInteractable>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (redGate.isCompleted && purpleGate.isCompleted && blueGate.isCompleted && greenGate.isCompleted)
        {
            gameObject.GetComponent<XRGrabInteractable>().enabled = true;
            // transition to acceptance scene
        }
    }
}
