using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int punti;

    public int playerEnergy;

    public int powerUp;

    public float time;

    public int nemici;

    public int maxNemici;

    public Text testoPunti;

    public Text testoEnergia;

    public Text testoTime;

    public Text testoPowerUp;

    public Creatore creatore;

    public PlayerScript player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        punti = 0;
        nemici = 0;
        maxNemici = 3;
        playerEnergy = 100;
        time = 0;
        powerUp = 0;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        testoTime.text = "Tempo: " + Mathf.RoundToInt(time);
        maxNemici = 3 + Mathf.FloorToInt(time / 30);
    }

    public void aumentaPowerUP(int nuoviPunti)
    {
        powerUp = powerUp + nuoviPunti;

        if (powerUp >= 5)
        {
            player.startPowerUp();
            powerUp = 0;
        }

        testoPowerUp.text = "PowerUP: " + powerUp;
    }

    public void aggiungiPunti(int nuoviPunti)
    {
        punti = punti + nuoviPunti;

        testoPunti.text = "Punti: " + punti;
    }

    public void aumentaNemici()
    {
        nemici++;
    }

    public void diminuisciNemici()
    {
        nemici--;
    }

    public void aumentaEnergia(int nuovaEnergia)
    {
        playerEnergy = playerEnergy + nuovaEnergia;

        testoEnergia.text = "Energia: " + playerEnergy;
    }

    public void diminuisciEnergia(int energiaPersa)
    {
        playerEnergy = playerEnergy - energiaPersa;

        testoEnergia.text = "Energia: " + playerEnergy;
    }

    public bool ilGiocatoreEVivo()
    {
        if (playerEnergy > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public bool possoMandareUnNuovoNemico()
    {
        if(nemici < maxNemici)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
