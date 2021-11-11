using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proiettile : MonoBehaviour
{

    public float velocita;

    // Start is called before the first frame update
    void Start()
    {
        velocita = 20f;

        Invoke("AutoDistruzione", 1);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * velocita * Time.deltaTime);
    }

    void AutoDistruzione()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    AutoDistruzione();    
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name.Equals("StarShip"))
        {
            
        }
        else
        {
            AutoDistruzione();
        }
    }
}
