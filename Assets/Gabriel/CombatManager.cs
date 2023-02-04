using System.Collections;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager singleton;
    public GameObject ally, enemy;
    public float hitRatio;
    public GameObject hitbar;
    public EstadoC estadoC;

    private void Awake()
    {
        if (singleton == null) singleton = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);


        hitbar.SetActive(false);
    }

    private void Update()
    {
    }

    public IEnumerator CambiarEstado(EstadoC e)
    {
        yield return new WaitForEndOfFrame();
        singleton.estadoC = e;
    }
}

public enum EstadoC
{
    POSITION = 0,
    ACCURACY = 1,
    HIT = 2
}