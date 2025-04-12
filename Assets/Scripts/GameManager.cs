using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score = 0;
    public int Score { get => score; set => score = value; }


    //Recoleccion de objetos
    private int objetosRec = 0;
    public int ObjetosRec { get => objetosRec; set => objetosRec = value; }

    private int bananasRec = 0;
    public int BananasRec { get => bananasRec; set => bananasRec = value; }

    private int manzanasVerdesRec = 0;
    public int ManzanasVerdesRec { get => manzanasVerdesRec; set => manzanasVerdesRec = value; }

    private int manzanasRojasRec = 0;
    public int ManzanasRojasRec { get => manzanasRojasRec; set => manzanasRojasRec = value; }

    public int uvasRec = 0;
    public int UvasRec { get => uvasRec; set => uvasRec = value; }

    private int sandiasRec = 0;
    public int SandiasRec { get => sandiasRec; set => sandiasRec = value; }

    //public int estrellas = 0;
    //public int Estrellas { get => estrellas; set => estrellas = value; }

    public int curaciones = 0;
    public int Curaciones { get => curaciones; set => curaciones = value; }

    public int piñasRec = 0;
    public int PiñasRec { get => piñasRec; set => piñasRec = value; }

    //Tiempo
    private float tiempoAcumulado = 0f;
    public float TiempoAcumulado { get => tiempoAcumulado; set => tiempoAcumulado = value; }


    //Cuerpo
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persistencia del GameManager entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RecolectarObjeto(int puntos, string objetoTipo)
    {
        score += puntos;
        objetosRec++; // Incrementa el conteo total de objetos

        // Contar la fruta específica
        
        if (objetoTipo == "Manzana")
        {
            manzanasRojasRec++;
        }
        else if (objetoTipo == "Sandia")
        {
            sandiasRec++;
        }
        else if (objetoTipo == "Uva")
        {
            uvasRec++;
        }
        else if (objetoTipo == "Banana")
        {
            bananasRec++;
        }
        else if (objetoTipo == "Manzana Verde")
        {
            manzanasVerdesRec++;
        }
        //else if (objetoTipo == "Estrella")
        //{
        //    estrellas++;
        //}
        else if (objetoTipo == "Curacion")
        {
            curaciones++;
        }
        else if (objetoTipo == "Piña")
        {
            piñasRec++;
        }
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void ResetTiempo()
    {
        tiempoAcumulado = 0f;
    }
}
