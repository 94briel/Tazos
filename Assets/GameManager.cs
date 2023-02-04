using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{   
    // parametros para la fuerza de lanzamiento
    public float pos;
    public bool sumando;
    public Slider potencia;
    public bool raton;
    // parametros Omar
    public static GameManager instance;
    public bool inGame = true;
    public GameObject tazo,target,star;
    public bool bonus = false;
    public TextMeshProUGUI pBonus;
    public float stopwatch;
    private void Awake()
    {
        inGame = true;
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }
    void Start()
    {
        StartCoroutine("Bonus");//inicia el spawn de las estrellas
    }

    void Update()
    {
        ShotForce();
    }
    public void ShotForce() 
    {
      if (raton==true)
        {
            if (sumando == true)
            {
                if (pos<1)
                {
                    pos = pos + Time.deltaTime;
                }
                else
                {
                 sumando = false;
                }
            }
            else
            {
                if (pos>0  )
                {
                    pos = pos - Time.deltaTime;
                }
                else
                {
                 sumando = true;
                }
            }
            potencia.value=pos;
        }
        if ( Input.GetMouseButtonDown(0))
        {
            raton = false;
        }
    }
    IEnumerator Bonus()// spawn de estrellas 
    {
        while (true)
        {
            if (bonus && stopwatch <= 2)
            {
                GameObject myStar;
                myStar = Instantiate(star, new Vector3(Random.Range(-7, 7), Random.Range(1f, 14f), 0f), Quaternion.identity);
                myStar.AddComponent<Star>();
                myStar.SetActive(true);
                yield return new WaitForSeconds(0.85f);  
                myStar.SetActive(false);
                yield return new WaitForSeconds(0.85f);
                stopwatch += 1;
            }
            yield return null;
        }
    }
}
