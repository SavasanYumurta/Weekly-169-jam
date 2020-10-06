using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{
    private Vector2 targetPosition;
    [SerializeField] private int speed;
    public bool gidebilirsin;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        gidebilirsin = false;
        if(collision.transform.tag == "MainAda")
        {
            SceneManager.LoadScene(1);
        }else if(collision.transform.tag == "OtherAda")
        {

        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        gidebilirsin = true;
    }

    void Update()
    {
        HealthSystem hs = GameObject.FindWithTag("Gemi").GetComponent<HealthSystem>();
        if(hs.Health < hs.maxHealth)
        {
            gidebilirsin = false;
        }else
        {
            gidebilirsin = true;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (gidebilirsin)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
        }
    }
}
