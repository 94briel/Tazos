using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class force : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(1000,-10000f,100));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
