using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antifire : MonoBehaviour
{
    public ParticleSystem PS;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        PS.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PS.Play();
            audioSource.Play();
        }
        if (Input.GetMouseButtonUp(0))
        {
            PS.Stop();
            audioSource.Stop();
        }
    }
}
