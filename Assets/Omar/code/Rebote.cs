using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebote : MonoBehaviour
{
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward *speed* Time.deltaTime;
        if (Input.GetButtonDown("Fire1"))
        {
            transform.position += Vector3.forward *speed* Time.deltaTime;
        }
    }
}
