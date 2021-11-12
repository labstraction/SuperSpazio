using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private Vector2 movimento;

    public float velocit‡;

    public float accellerazione;

    public Proiettile proiettile;

    public float frequenzaDiSparo;

    private float tempoDiSparo;

    private GameManager gameManager;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        movimento = Vector2.zero;
        velocit‡ = 12f;
        accellerazione = 90f;
        frequenzaDiSparo = 0.5f;
        tempoDiSparo = 0;
        gameManager = FindObjectOfType<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        //movimento.y = Input.GetAxisRaw("Vertical");
        ////Debug.Log("Movimento su asse verticale: " + movimento.y);
        //movimento.x = Input.GetAxisRaw("Horizontal");
        //// Debug.Log("Movimento su asse orizzontale: " + movimento.x)
        ///
        movimento.x = 0;
        movimento.y = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movimento.x--;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movimento.x++;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movimento.y++;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movimento.y--;
        }


        tempoDiSparo = tempoDiSparo + Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && tempoDiSparo > frequenzaDiSparo)
        {
            tempoDiSparo = 0;
            Instantiate(proiettile, transform.position, Quaternion.identity);
        }


        Vector3 posizioneRispettoAllaCamera = Camera.main.WorldToViewportPoint(rb2d.position);

        posizioneRispettoAllaCamera.x = Mathf.Clamp01(posizioneRispettoAllaCamera.x);
        posizioneRispettoAllaCamera.y = Mathf.Clamp01(posizioneRispettoAllaCamera.y);

        Vector3 velocit‡Attuale = rb2d.velocity;

        if (posizioneRispettoAllaCamera.x == 0 || posizioneRispettoAllaCamera.x == 1)
        {
            velocit‡Attuale.x = -velocit‡Attuale.x;
        }
        if (posizioneRispettoAllaCamera.y == 0 || posizioneRispettoAllaCamera.y == 1)
        {
            velocit‡Attuale.y = -velocit‡Attuale.y;
        }

        rb2d.velocity = velocit‡Attuale;

    

        rb2d.position = Camera.main.ViewportToWorldPoint(posizioneRispettoAllaCamera);



        
    }

    void FixedUpdate()
    {

        //Vector2 movimentoInBaseAllaVelocit‡ = movimento * velocit‡ * Time.fixedDeltaTime;
        //Vector2 spostamento = rb2d.position + movimentoInBaseAllaVelocit‡;
        //rb2d.MovePosition(spostamento);

        Vector2 forza = movimento * accellerazione * Time.fixedDeltaTime;

        rb2d.AddForce(forza);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name.Equals("Proiettile(Clone)"))
        {

        } else
        {
            gameManager.diminuisciEnergia(20);
            if (!gameManager.ilGiocatoreEVivo())
            {
                AutoDistruzione();
            }
            
        }
        
    }

    void AutoDistruzione()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
