using System.Collections;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0, 2)] public float duration = .1f;

    public float speed = 1f;

    public Vector3 initialPosition;
    public float movement = .4f;
    public float widthSize;
    private Coroutine coroutineMove;

    private void Start()
    {
        initialPosition = new Vector3(Random.Range(-.3f, .3f), 0.67f, 2.146f);
        widthSize = GetWidthSize();
        movement = Mathf.Clamp(Random.Range(movement, widthSize), movement, widthSize);
        coroutineMove = StartCoroutine(Move());
    }

    private void Update()
    {
    }

    // Update is called once per frame
    private void OnEnable()
    {
        EventController.singleton.playTazo += GiveDistance;
    }

    private void OnDisable()
    {
        EventController.singleton.playTazo -= GiveDistance;
    }

    private float CalculateXDistance(Transform a, Transform b)
    {
        return Mathf.Abs(a.position.x - b.position.x);
    }

    private float GetWidthSize()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, transform.position.z)).x;
    }

    private float GiveDistance()
    {
        EventController.singleton.playTazo -= GiveDistance;
        StopCoroutine(coroutineMove);
        return CalculateXDistance(CombatManager.singleton.ally.transform, CombatManager.singleton.enemy.transform) /
               widthSize;
    }

    private IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / 60f);
            transform.position = initialPosition + Mathf.Sin(Time.time * speed) * new Vector3(movement, 0f, 0f);
            initialPosition = initialPosition + new Vector3(Random.Range(-.001f, .001f), 0, 0);
        }
    }
}