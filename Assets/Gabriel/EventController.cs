using System;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public static EventController singleton;
    public estadoCombate eCombate;

    private void Awake()
    {
        if (singleton == null)
            singleton = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        CombatEvents();
    }

    public event Func<float> playTazo;
    public event Func<bool> moveSlide;

    private void CombatEvents()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        switch (CombatManager.singleton.estadoC)
        {
            case 0:

                CombatManager.singleton.hitRatio = playTazo?.Invoke() ?? -1;
                StartCoroutine(CombatManager.singleton.CambiarEstado(EstadoC.ACCURACY));
                CombatManager.singleton.hitbar.SetActive(true);
                break;
            case (EstadoC)1:
                StartCoroutine(CombatManager.singleton.CambiarEstado(EstadoC.HIT));
                moveSlide?.Invoke();
                Debug.Log("xd");
                break;
            case (EstadoC)2:
                break;
        }
    }
}

public enum estadoCombate
{
    POSICIONAMIENTO = 0,
    POTENCIACION = 1,
    LANZAMIENTO = 2,
    DISPARO = 3
}