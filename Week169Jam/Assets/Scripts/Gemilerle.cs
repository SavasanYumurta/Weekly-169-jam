using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gemilerle : MonoBehaviour
{
 
    public void Update()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0.3f, 0);
    }
}
