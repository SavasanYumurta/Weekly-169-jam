using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vurmaca : MonoBehaviour
{
    public List<Image> obj;
    private int i, answer;
    public float gerekenAnswer;
    public void Start()
    {
        obj[0] = transform.GetChild(0).gameObject.GetComponent<Image>();
        obj[1] = transform.GetChild(1).gameObject.GetComponent<Image>();
        obj[2] = transform.GetChild(2).gameObject.GetComponent<Image>();
        obj[3] = transform.GetChild(3).gameObject.GetComponent<Image>();
        obj[4] = transform.GetChild(4).gameObject.GetComponent<Image>();
        obj[5] = transform.GetChild(5).gameObject.GetComponent<Image>();
        obj[6] = transform.GetChild(6).gameObject.GetComponent<Image>();
        obj[7] = transform.GetChild(7).gameObject.GetComponent<Image>();
        obj[8] = transform.GetChild(8).gameObject.GetComponent<Image>();

        StartCoroutine (Salla());
    }
    IEnumerator Salla()
    {
        i = Random.Range(0, 8);
        obj[i].color = Color.gray;
        yield return new WaitForSeconds(1f);
        if (obj[i].color == Color.gray)
        {
            obj[i].color = Color.white;
            answer--;
        }
        StartCoroutine(Salla());
    }

    public void Update()
    {
        if(answer == gerekenAnswer)
        {
            GameObject.FindWithTag("Gemi").GetComponent<HealthSystem>().Health = GameObject.FindWithTag("Gemi").GetComponent<HealthSystem>().maxHealth;
            GameObject.FindWithTag("GameController").GetComponent<Manager>().GemiPatlak = false;
            this.gameObject.SetActive(false);
        }
    }
    public void Kapat()
    {
        this.gameObject.SetActive(false);
    }
    public void Bir()
    {
        if(i == 0)
        {
            answer++;
            obj[i].color = Color.white;
        }
    }
    public void Iki()
    {
        if (i == 1)
        {
            answer++;
            obj[i].color = Color.white;
        }
    }
    public void Uc()
    {
        if (i == 2)
        {
            answer++;
            obj[i].color = Color.white;
        }
    }
    public void Dort()
    {
        if (i == 3)
        {
            answer++;
            obj[i].color = Color.white;
        }
    }
    public void Bes()
    {
        if (i == 4)
        {
            answer++;
            obj[i].color = Color.white;
        }
    }
    public void Altı()
    {
        if (i == 5)
        {
            answer++;
            obj[i].color = Color.white;
        }
    }
    public void Yedi()
    {
        if (i == 6)
        {
            answer++;
            obj[i].color = Color.white;
        }
    }    
    public void Sekiz()
    {
        if (i == 7)
        {
            answer++;
            obj[i].color = Color.white;
        }
    }    
    public void  Dokuz()
    {
        if (i == 8)
        {
            answer++;
            obj[i].color = Color.white;
        }
    }
}
