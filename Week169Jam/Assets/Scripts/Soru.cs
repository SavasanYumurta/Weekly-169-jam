using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Soru")]
public class Soru : ScriptableObject
{
    [TextArea(4,6)] public string soru;
    [SerializeField] private string birinciC,ikinciC,UcuncuC;
    [SerializeField] private Soru C1Soru, C2Soru, C3Soru;

    public Soru GetSiradakiSoru()
    {
        return C1Soru;
    }
}
