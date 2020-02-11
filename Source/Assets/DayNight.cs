using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }
    private void Update()
    {
        Vector3 rotate = new Vector3(0.05f, 0, 0);
        rb.transform.Rotate(rotate); //Rotiranje kockica
    }
    
}
