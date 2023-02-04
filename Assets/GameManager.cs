using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
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
        StartCoroutine("Bonus");
    }

    void Update()
    {
        
    }
    IEnumerator Bonus()
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
