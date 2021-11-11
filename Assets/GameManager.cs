using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int punti;

    public int nemici;

    public int maxNemici;

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
        maxNemici = 5;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void aggiungiPunti(int nuoviPunti)
    {
        punti = punti + nuoviPunti;

        Debug.Log("Punti: " + punti);
    }

    public void aumentaNemici()
    {
        nemici++;
    }

    public void diminuisciNemici()
    {
        nemici--;
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
