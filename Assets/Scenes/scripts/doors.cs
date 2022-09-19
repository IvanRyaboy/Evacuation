using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doors : MonoBehaviour
{
    public GameObject door;
    private Animator anim;

    void Start()
    {
        anim = door.GetComponent<Animator>();
    }

    void OnTriggerEnter()
    {
        anim.SetBool("IsOpen", true);
    }

    void OnTriggerExit()
    {
        anim.SetBool("IsOpen", false);
    }
}
