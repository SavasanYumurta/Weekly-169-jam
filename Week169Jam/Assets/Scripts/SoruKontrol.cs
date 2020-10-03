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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            mevcutSoru = mevcutSoru.GetSiradakiSoru();
            SorularıAl();
        }
    }
    private void SorularıAl()
    {
        soruBolum.transform.GetChild(0).GetComponent<Text>().text = mevcutSoru.soru;
    }
}
