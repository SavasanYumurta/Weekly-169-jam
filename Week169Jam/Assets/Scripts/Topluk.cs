using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topluk : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    public void Update()
    {
        float dis = (Vector2.Distance(player.transform.position, this.transform.position));
        if (dis <= 2)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                TopAl();
            }
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    public void TopAl()
    {
        player.GetComponent<Karakter>().isMermi = true;
        player.transform.GetChild(0).gameObject.SetActive(true);
    }
}
