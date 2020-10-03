using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public void Update()
    {
        float dis = (Vector2.Distance(player.transform.position, this.transform.position));
        if (dis <= 2)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                Ates();
            }
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    public void Ates()
    {
        print("ates");
    }
}
