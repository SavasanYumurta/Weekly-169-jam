using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float Health,maxHealth,bozuklukMax,bozukluk;
    [SerializeField] private int Sira;
    [SerializeField] private GameObject Bar,Player;
    [SerializeField] private bool bozuk;
    public void Start()
    {
        Player = GameObject.FindWithTag("Player");
        Bar = transform.GetChild(Sira -1).gameObject;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!bozuk)
        {
            if (collision.tag == "TopMermi")
            {
                Destroy(collision.gameObject);
                Health -= 50;
            }
        }
    }
    public void Update()
    {
        if (!bozuk)
        {
            if (Health > maxHealth)
            {
                Health = maxHealth;
            }
            else if (Health <= 0)
            {
                bozukluk = bozuklukMax;
                Bozul();
            }
            Bar.transform.GetChild(0).localScale = new Vector2((Health / maxHealth), Bar.transform.localScale.y);
            Bar.transform.GetChild(0).localPosition = new Vector3(0.5f + (-1 * (1 - ((Health / maxHealth)) / 2)), 0, -0.001f);
        }
        else
        {
            if (Input.GetKey(KeyCode.F))
            {
                bozukluk -= Time.deltaTime * Player.GetComponent<Karakter>().repairSpeed;
                if(bozukluk <= 0)
                {
                    Bar.transform.GetChild(1).gameObject.SetActive(false);
                    this.GetComponent<Animator>().SetTrigger("rep");
                    bozuk = false;
                    Health = maxHealth;
                }
            }
        }
    }
    public void Bozul()
    {
        this.GetComponent<Animator>().SetTrigger("bom");
        Bar.transform.GetChild(1).gameObject.SetActive(true);
        bozuk = true;
    }
}
