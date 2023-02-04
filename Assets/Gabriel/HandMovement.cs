using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class HandMovement : MonoBehaviour, IPointerClickHandler 
{
    [Range(0, 2)]
    public float duration = .1f;

    public float movementX = .4f;

    public Transform ally, enemy;
    void Start()
    {
        StartCoroutine(Move());
    }
    void Update()
    {
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Debug.Log("dweede");
        ReturnDistance();
    }

    private float CalculateDistance(Transform ally, Transform enemy)
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Debug.Log(Mathf.Abs(ally.position.x - enemy.position.x));

        return Mathf.Abs(ally.position.x - enemy.position.x);
    }

    private float ReturnDistance()
    { 
        StopCoroutine("Move");
       return CalculateDistance(GameManager.instance.tazoAliado,GameManager.instance.target.transform);
    }
    
    IEnumerator Move(bool orientation = true)
    {
        Vector3 initialPosition = transform.position;
        
        float lerpDuration = duration + Random.Range(-.01f, .01f);
        lerpDuration = Mathf.Clamp(duration,0.0001f, duration);

        float lerpPosition = movementX;
        lerpPosition = orientation ? lerpPosition : -lerpPosition;
        float timeElapsed = 0;
        
        
        Vector3 newPosition = new Vector3(lerpPosition + initialPosition.x, initialPosition.y, initialPosition.z);
        while (timeElapsed < lerpDuration)
        {
            transform.position = Vector3.Lerp(initialPosition, newPosition, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        timeElapsed = 0f;
        lerpDuration = duration + Random.Range(-.01f, .01f);;
        while (timeElapsed < lerpDuration)
        {
            transform.position = Vector3.Lerp(newPosition, transform.position, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        yield return Move(!orientation);
    }
}
