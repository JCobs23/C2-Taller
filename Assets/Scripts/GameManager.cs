using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score = 0;
    public int Score { get => score; set => score = value; }

    private float tiempoAcumulado = 0f;
    public float TiempoAcumulado { get => tiempoAcumulado; set => tiempoAcumulado = value; }

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

    public void SumValues(int count)
    {
        score += count;
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
