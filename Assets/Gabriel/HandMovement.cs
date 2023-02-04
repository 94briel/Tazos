using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class HandMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0, 2)]
    public float duration = .1f;

    public float speed = 1f;

    public Transform ally, enemy;

    public Vector3 initialPosition;
    public float movement = .4f;
    void Start()
    { 
        initialPosition = transform.position;
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void OnEnable()
    {
        EventController.singleton.playTazo += ReturnDistance;
    }
    
    void OnDisable()
    {
        EventController.singleton.playTazo -= ReturnDistance;
    }

    private float CalculateDistance(Transform ally, Transform enemy)
    {
        return Mathf.Abs(ally.position.x - enemy.position.x);
    }

    private float ReturnDistance()
    { 
        StopCoroutine("Move");
        return CalculateDistance(ally, enemy);
    }

    IEnumerator Move(bool orientation = true)
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / 60f);
            transform.position = initialPosition + Mathf.Sin(Time.time * speed) * new Vector3(movement, 0f,0f);
            
        }
    }
    
}
