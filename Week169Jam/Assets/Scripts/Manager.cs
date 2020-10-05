using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField] private Soru PatlamaSorusu,currenSoru;
    private bool soru;
    [SerializeField] private GameObject soruBolum;
    
    public void Update()
    {
        if (soru)
        {
            if (!currenSoru.oynanıs)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    if(currenSoru.CS >= 1)
                    {
                        currenSoru = currenSoru.GetSiradakiSoru1();
                        Sorularıİsle();
                    }
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    if(currenSoru.CS >= 2)
                    {
                        currenSoru = currenSoru.GetSiradakiSoru2();
                        Sorularıİsle();
                    }
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    if(currenSoru.CS == 3)
                    {
                        currenSoru = currenSoru.GetSiradakiSoru3();
                        Sorularıİsle();
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    Oynanıs(1);
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    Oynanıs(2);
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    Oynanıs(3);
                }
            }
            
        }
    }
    public void Sorularıİsle()
    {
        soruBolum.transform.GetChild(0).GetComponent<Text>().text = currenSoru.soru;
        if(currenSoru.CS >= 1)
        {
            soruBolum.transform.GetChild(1).GetComponent<Text>().text = currenSoru.birinciC;
            if (currenSoru.CS >= 2) { soruBolum.transform.GetChild(2).GetComponent<Text>().text = currenSoru.ikinciC; }
            if (currenSoru.CS == 3) { soruBolum.transform.GetChild(3).GetComponent<Text>().text = currenSoru.UcuncuC; }
        }
    }
    public void SorularıAl(Soru soru)
    {
        currenSoru = soru;
        Sorularıİsle();
    }
    public void MapAcKapa()
    {
        soru = !soru;
        transform.GetChild(0).gameObject.SetActive(soru);
    }
    public void Patla()
    {
        MapAcKapa();
        SorularıAl(PatlamaSorusu);
    }
    public void Oynanıs(float cevap)
    {

        if(currenSoru = PatlamaSorusu)
        {
            if(cevap == 1)
            {
                PlayerPrefs.SetFloat("Gold", PlayerPrefs.GetFloat("Gold") - 1000);
                GameObject.FindWithTag("enemyShip").SetActive(false);
                MapAcKapa();
                
            }else if (cevap == 2)
            {
                SceneManager.LoadScene(1); //esir sceneyi
            }else if(cevap == 3)
            {

            }
        }
    }
}
