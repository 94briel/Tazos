using UnityEngine;

public class tazo : MonoBehaviour
{
    private void Start()
    {
    }

    private void Update()
    {
    }

    private void OnMouseDown()
    {
        GameObject myTazo;
        myTazo = Instantiate(GameManager.instance.tazo, transform.position, Quaternion.identity);
    }
}