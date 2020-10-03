using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    public GameObject mermi;
    public GameObject yazi;
    public GameObject Topy;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "TopMermi")
        {
            Debug.Log("Deydi");
            yazi.SetActive(true);
        }
    }
    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform.tag == "TopMermi")
        {
            Debug.Log("Deydi");
            yazi.SetActive(false);
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
       
    if (collision.transform.tag == "TopMermi")
           {
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