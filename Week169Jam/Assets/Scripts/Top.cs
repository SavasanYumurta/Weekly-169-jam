using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    public GameObject mermi;
    public GameObject yazi;
    public GameObject Topy;

    public void OnTriggerEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "TopMermi")
        {
            Debug.Log("Deydi");
            yazi.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                mermi.SetActive(true);
                StartCoroutine(Topp());
            }

        }
    }
    IEnumerator Topp()
    {

        yield return new WaitForSeconds(0.66f);
        mermi.SetActive(false);
    }
  
}