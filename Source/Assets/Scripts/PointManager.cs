using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    private float rot=2; //rotacija

    Rigidbody rb; //Vucem komponentu Rigidbody

    void Start()
    {
        rb=GetComponent<Rigidbody>(); 
    }
    private void FixedUpdate() //Sluzi za kretanja
    {
        Vector3 rotate = new Vector3(rot, rot, rot); 
        rb.transform.Rotate(rotate); //Rotiranje kockica
    }
}