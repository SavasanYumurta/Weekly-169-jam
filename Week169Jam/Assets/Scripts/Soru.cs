using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Soru")]
public class Soru : ScriptableObject
{
    [TextArea(4,6)][SerializeField] private string soru;
    [SerializeField] private string birinciC,ikinciC,UcuncuC;
}
