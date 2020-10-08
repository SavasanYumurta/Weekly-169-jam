using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float Health,maxHealth,bozuklukMax,bozukluk;
    public int Sira;
    [SerializeField] private GameObject Bar,Player;
    [SerializeField] private bool bozuk,kaybet ,thisGemi,thisEnemyShip;
    [SerializeField] private Manager manager;
    private bool Can700Animg, Can400Animg, Can0Animg;
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
            else if (Health == 700) 
            { 
                if(Can700Animg && thisGemi)
                {
                    Can700Animg = true;
                    this.GetComponent<Animator>().SetTrigger("400");
                }
            }
            else if (Health == 400)
            {
                if (Can400Animg && thisGemi)
                {
                    Can400Animg = true;
                    this.GetComponent<Animator>().SetTrigger("400");
                }
            }
            else if (Health <= 0)
            {
                if (!thisGemi)
                {
                    bozukluk = bozuklukMax;
                    Bozul();
                }
                else if (thisGemi)
                {
                    Kaybet();
                }
                else if (thisEnemyShip)
                {
                    Kazan();
                }
            }
            
            Bar.transform.GetChild(0).localScale = new Vector2((Health / maxHealth), Bar.transform.GetChild(0).localScale.y);
            Bar.transform.GetChild(0).localPosition = new Vector3(0.5f + (-1 * (1 - ((Health / maxHealth)) / 2)), 0, -0.001f);
        }
        else
        {
            if (Input.GetKey(KeyCode.F))
            {
                Bar.transform.GetChild(0).localScale = new Vector2(1 - (bozukluk / bozuklukMax), Bar.transform.GetChild(0).localScale.y);
                Bar.transform.GetChild(0).localPosition = new Vector3(0.5f + (-1 * (1 - (((100 - bozukluk) / bozuklukMax)) / 2)), 0, -0.001f);
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
    public void Kaybet()
    {
        if (!kaybet)
        {
            kaybet = true;
            manager.Patla();
        }
    }
    public void Kazan() { [
        ]}
}
