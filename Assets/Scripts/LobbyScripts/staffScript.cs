using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staffScript : MonoBehaviour
{
    AudioSource awakeAudio;

    private void Awake()
    {
        awakeAudio.Play();
    }
}
