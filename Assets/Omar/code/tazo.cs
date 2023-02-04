using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tazo : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        GameObject myTazo;
        myTazo = Instantiate(GameManager.instance.tazo,transform.position,Quaternion.identity);
    }
}
