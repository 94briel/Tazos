using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rebote : MonoBehaviour
{
    public float speed;
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += Vector3.forward *speed* Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.name == "target")
        {
            GameManager.instance.bonus = true;
        }
    }
}
