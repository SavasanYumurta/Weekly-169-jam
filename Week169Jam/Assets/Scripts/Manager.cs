using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField] private Soru PatlamaSorusu,currenSoru;
    private bool soru,map,ara;
    public bool GemiPatlak,savasta;
    [SerializeField] private GameObject soruBolum,mapB,UI,eShip,direksiyon;
    public int score;
    public float zaman,zamanT;
    
    /*public void Update()
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
    public void SoruAcKapa()
    {
        soru = !soru;
        transform.GetChild(0).gameObject.SetActive(soru);
    }
    public void MapAcKapa()
    {
        if (!savasta)
        {
            map = !map;
            transform.GetChild(1).gameObject.SetActive(!map);
            mapB.SetActive(map);
            GameObject.FindWithTag("MainCamera").GetComponent<Animator>().SetBool("isMap", true);
        }
    */
    public void Patla()
    {
        GemiPatlak = true;
        if(score > PlayerPrefs.GetInt("BS", 0)){
            PlayerPrefs.SetInt("BS", score);
        }
        GameObject GO = UI.transform.GetChild(3).gameObject;
        GO.SetActive(true);
        GO.transform.GetChild(2).GetComponent<Text>().text = "Your Score :" + score;
        GO.transform.GetChild(3).GetComponent<Text>().text = "Best Score :" + PlayerPrefs.GetInt("BS", score);
    }
    public void Kazan()
    {
        score += Random.Range(500, 2500);
        zaman = zamanT;
        ara = true;
        Destroy(GameObject.FindWithTag("enemyShip").gameObject);
        transform.GetChild(4).gameObject.SetActive(true);
        savasta = false;
        direksiyon.SetActive(true);
    }
    public void Update()
    {
        if (ara)
        {
            transform.GetChild(4).GetComponent<Text>().text = zaman.ToString();
            zaman -= Time.deltaTime;
            if(zaman <= 0)
            {
                ara = false;
                GameObject go = Instantiate(eShip, new Vector2(70, 0), Quaternion.identity);
                go.transform.localScale = new Vector2(-1, 1);
                transform.GetChild(4).gameObject.SetActive(false);
                savasta = true;
                direksiyon.SetActive(false);
            }
        }
    }
    public void reset()
    {
        SceneManager.LoadScene(1);
    }
    /*
    public void Oynanıs(float cevap)
    {

        if(currenSoru = PatlamaSorusu)
        {
            if(cevap == 1)
            {
                PlayerPrefs.SetFloat("Gold", PlayerPrefs.GetFloat("Gold") - 1000);
                GameObject.FindWithTag("enemyShip").SetActive(false);
                SoruAcKapa();
                
            }else if (cevap == 2)
            {
                SceneManager.LoadScene(1); //esir sceneyi
            }else if(cevap == 3)
            {

            }
        }
    */
}
