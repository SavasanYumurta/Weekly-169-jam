using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    [SerializeField] private GameObject yazi, mermi, player,atısAcı,vurusHiz;
    [SerializeField] private float topSpeed, topSpeedArt;
    private bool mermili;
    public void Start()
    {
        atısAcı = transform.GetChild(1).gameObject;
        topSpeed = 100;
        player = GameObject.FindWithTag("Player");
        vurusHiz = transform.GetChild(2).gameObject;
        vurusHiz.SetActive(false);
    }
    public void Update()
    {
        vurusHiz.transform.GetChild(0).transform.localScale = new Vector2((topSpeed - 100) / 400,1);
        float dis = (Vector2.Distance(player.transform.position, this.transform.position));
        if (dis <= 2)
        {
            if (player.GetComponent<Karakter>().isMermi)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.R))
                {
                    vurusHiz.SetActive(true);
                }
                if (Input.GetKey(KeyCode.R))
                {
                    if (topSpeed <= 500)
                    {
                        topSpeed += topSpeedArt * Time.deltaTime;
                    }
                }
                if (Input.GetKeyUp(KeyCode.R))
                {
                    player.GetComponent<Karakter>().isMermi = false;
                    player.transform.GetChild(0).gameObject.SetActive(false);
                    mermili = true;
                    vurusHiz.SetActive(true);
                }

            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (mermili)
                {
                    mermili = false;
                    Topp();
                    topSpeed = 100;
                }
            }
        }
        else
        {
            vurusHiz.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    public void Topp()
    {
        GameObject go = Instantiate(mermi, transform.position, Quaternion.identity);
        go.GetComponent<Rigidbody2D>().AddForce(new Vector2(atısAcı.transform.position.x,atısAcı.transform.position.y) * topSpeed);
        topSpeed = 200;
        vurusHiz.SetActive(false);
    }

}