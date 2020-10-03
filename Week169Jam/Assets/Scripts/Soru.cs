using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Soru")]
public class Soru : ScriptableObject
{
    [TextArea(4,6)] public string soru;
    [TextArea(4, 6)] public string birinciC,ikinciC,UcuncuC;
    [SerializeField] private Soru C1Soru, C2Soru, C3Soru;
    [SerializeField] private bool oynanıs;

    public Soru GetSiradakiSoru1()
    {
        return C1Soru;
    }
    public Soru GetSiradakiSoru2()
    {
        return C2Soru;
    }
    public Soru GetSiradakiSoru3()
    {
        return C3Soru;
    }
}
