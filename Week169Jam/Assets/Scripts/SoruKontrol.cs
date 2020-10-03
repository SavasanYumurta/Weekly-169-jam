using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoruKontrol : MonoBehaviour
{
    [SerializeField] private Soru baslangicSorusu;
    private Soru mevcutSoru;
    [SerializeField] private GameObject soruBolum;
    private void Start()
    {
        mevcutSoru = baslangicSorusu;
        SorularıAl();
    }
    public void Update()
    {
        SorularıAl();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            mevcutSoru = mevcutSoru.GetSiradakiSoru1();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            mevcutSoru = mevcutSoru.GetSiradakiSoru2();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            mevcutSoru = mevcutSoru.GetSiradakiSoru3();
        }
    }
    private void SorularıAl()
    {
        soruBolum.transform.GetChild(0).GetComponent<Text>().text = mevcutSoru.soru;
        soruBolum.transform.GetChild(1).GetComponent<Text>().text = mevcutSoru.birinciC;
        soruBolum.transform.GetChild(2).GetComponent<Text>().text = mevcutSoru.ikinciC;
        soruBolum.transform.GetChild(3).GetComponent<Text>().text = mevcutSoru.UcuncuC;
    }
}
