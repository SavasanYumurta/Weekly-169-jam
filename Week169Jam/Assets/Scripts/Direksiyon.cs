using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direksiyon : MonoBehaviour
{
    
    private GameObject player;
    [SerializeField] private GameObject Minigame;
    public void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    public void Update()
    {
        float dis = (Vector2.Distance(player.transform.position, this.transform.position));
        if (dis <= 2)
        {
            if (GameObject.FindWithTag("Gemi").GetComponent<HealthSystem>().Health < GameObject.FindWithTag("Gemi").GetComponent<HealthSystem>().maxHealth)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Minigame.SetActive(true);
                }
            }
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    public void MapAc()
    {
        
    }
}

