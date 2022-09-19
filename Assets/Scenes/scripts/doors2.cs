using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doors2 : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;
    private Animator anim1;
    private Animator anim2;

    void Start()
    {
        anim1 = door1.GetComponent<Animator>();
        anim2 = door2.GetComponent<Animator>();
    }

    void OnTriggerEnter()
    {
        anim1.SetBool("IsOpen", true);
        anim2.SetBool("IsOpen", true);
    }

    void OnTriggerExit()
    {
        anim1.SetBool("IsOpen", false);
        anim2.SetBool("IsOpen", false);
    }
}
