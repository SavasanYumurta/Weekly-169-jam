using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    [SerializeField] private GameObject player, Mermi;
    [SerializeField] private CameraFollow camFol;
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
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    public void Ates()
    {
        Instantiate(Mermi,new Vector2(transform.position.x,transform.position.y),Quaternion.identity);
        camFol.topVarmi = true;
        print("ates");
    }
}
