using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    [SerializeField] private GameObject player, Mermi;
    [SerializeField] private CameraFollow camFol;
    [SerializeField] private float offsetx,offsety;
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
        GameObject go = Instantiate(Mermi,new Vector3(transform.position.x + offsetx,transform.position.y + offsety,-1),Quaternion.identity);
        camFol.topVarmi = true;
        camFol.Top = go.transform;
        print("ates");
    }
}
