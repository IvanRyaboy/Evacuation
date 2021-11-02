using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuch : MonoBehaviour
{
private void OnCollisionEnter(Collision other) 
    {
        Debug.Log("Я коснулся");
    }
}
