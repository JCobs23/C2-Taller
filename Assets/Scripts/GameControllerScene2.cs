using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameControllerScene2 : MonoBehaviour
{
    public RankingManager rankingManager; 
    public TextMeshProUGUI txtAppleScore;

    private float tiempoJugado;
    private bool nivelTerminado = false;

    void Start()
    {
        tiempoJugado = 0f;
    }

    void Update()
    {
        if (!nivelTerminado)
        {
            tiempoJugado += Time.deltaTime;
            ShowScore();

            
            if (GameManager.Instance.Score >= 10)
            {
                nivelTerminado = true;

                // Llamamos al rankingManager
                rankingManager.MostrarRanking(
                    frutas: GameManager.Instance.Score,
                    puntuacion: GameManager.Instance.Score * 100, 
                    tiempo: tiempoJugado
                );
            }
        }
    }

    public void ShowScore()
    {
        txtAppleScore.text = GameManager.Instance.Score.ToString();
    }
}
