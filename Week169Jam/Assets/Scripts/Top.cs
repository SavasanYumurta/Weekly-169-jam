using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    [SerializeField] private GameObject yazi, mermi, player, atısAcı, vurusHiz, cam;
    [SerializeField] private float topSpeed, topSpeedArt;
    private bool artır;
    private bool mermili;
    public void Start()
    {
        cam = GameObject.FindWithTag("MainCamera");
        atısAcı = transform.GetChild(1).gameObject;
        topSpeed = 100;
        player = GameObject.FindWithTag("Player");
        vurusHiz = transform.GetChild(2).gameObject;
        vurusHiz.SetActive(false);
    }
    public void Update()
    {
        if (topSpeed < 100)
        {
            artır = true;
        }else if(topSpeed > 500)
        {
            artır = false;
        }
        vurusHiz.transform.GetChild(0).transform.localScale = new Vector2((topSpeed - 100) / 400, 1);
        float dis = (Vector2.Distance(player.transform.position, this.transform.position));
        if (dis <= 2)
        {
            if (player.GetComponent<Karakter>().isMermi)
            {
                if (!mermili)
                {
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        transform.GetChild(0).gameObject.SetActive(false);
                        cam.GetComponent<Animator>().SetTrigger("SavasGir");
                        vurusHiz.transform.localScale = new Vector2(50, 4);
                        vurusHiz.SetActive(true);
                    }
                    if (Input.GetKey(KeyCode.R))
                    {
                        if (artır)
                        {
                            topSpeed += topSpeedArt * Time.deltaTime;
                        }else if (!artır)
                        {
                            topSpeed -= topSpeedArt * Time.deltaTime;
                        }
                    }
                    else
                    {
                        transform.GetChild(0).gameObject.SetActive(true);
                    }
                    if (Input.GetKeyUp(KeyCode.R))
                    {
                        player.GetComponent<Karakter>().isMermi = false;
                        player.transform.GetChild(0).gameObject.SetActive(false);
                        StartCoroutine(SavasCık());
                        vurusHiz.transform.localScale = new Vector2(12, 1);
                        mermili = false;
                        Topp();
                        topSpeed = 100;
                        player.GetComponent<Karakter>().speed *= 2;
                    }
                }

            }
        }
        else
        {
            vurusHiz.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    IEnumerator SavasCık()
    {
        yield return new WaitForSeconds(2f);
        cam.GetComponent<Animator>().SetTrigger("SavasCık");
    }
    public void Topp()
    {
        GameObject go = Instantiate(mermi, transform.position, Quaternion.identity);
        go.GetComponent<Rigidbody2D>().AddForce(new Vector2(atısAcı.transform.position.x, atısAcı.transform.position.y) * topSpeed);
        StartCoroutine (Ac(go));
        topSpeed = 200;
        Destroy(go, 10f);
        vurusHiz.SetActive(false);
    }
    IEnumerator Ac(GameObject go)
    {
        yield return new WaitForSeconds(0.3f);
        go.GetComponent<CircleCollider2D>().enabled = true;
    }

}