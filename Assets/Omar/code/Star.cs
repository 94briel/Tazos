using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private float stopwatch; 

    void Start()
    {
        
    }
    void Update()
    {
       Invoke("Despanw",5);
    }
    public void Despanw ()
    {
        Destroy(gameObject);
    }
    
}
