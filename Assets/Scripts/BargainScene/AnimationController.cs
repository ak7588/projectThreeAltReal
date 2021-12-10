using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public GameObject NPC;
    Animator animator;
    int count = 0;

    private void Awake()
    {
        animator = NPC.GetComponent<Animator>();
    }

    private void Start()
    {
        // find by tag the scene with a tag and set load to true when user is done
    }

    private void OnTriggerEnter(Collider other)
    {
        if (count < 1)
        {
            count++;
            animator.SetBool("isTalking", true);
            StartCoroutine("NPCTalking");
            
            //if (other.CompareTag("Bargain"))
            //{
            //    animator.SetBool("isTalking", true);
            //    StartCoroutine("NPCTalking");
            //}
            //count++;
        }
        
    }

    IEnumerator NPCTalking()
    {
        // play audio
        yield return new WaitForSeconds(10);
        animator.SetBool("isTalking", false);
        yield return null;
    }
}
