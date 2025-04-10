using UnityEngine;
using System.Collections; // Necesario para corrutinas
using System.Collections.Generic; // Necesario para listas
using TMPro; // Necesario para usar TextMeshPro

public class Cronometro : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoCronometro; // Texto donde se mostrara el cronómetro
    [SerializeField] private float tiempo; // Tiempo acumulado

    private int tiempoMinutos;
    private int tiempoSegundos;
    private int tiempoMilisegundos;

    private bool cronometroActivo = true; // Controla si el cronometro esta funcionando o no

    void Update()
    {
        ActualizarCronometro();
    }

    void ActualizarCronometro()
    {
        if (cronometroActivo == true)
        {
            tiempo += Time.deltaTime;

            tiempoMinutos = Mathf.FloorToInt(tiempo / 60);
            tiempoSegundos = Mathf.FloorToInt(tiempo % 60);
            tiempoMilisegundos = Mathf.FloorToInt((tiempo - (tiempoSegundos + tiempoMinutos * 60)) * 100);

            if (textoCronometro != null)
            {
                textoCronometro.text = string.Format("{0:00}:{1:00}:{2:00}", tiempoMinutos, tiempoSegundos, tiempoMilisegundos);
            }
        }
    }

    public void DetenerTiempo()
    {
        cronometroActivo = false;
    }

    public void ReanudarTiempo()
    {
        cronometroActivo = true;
    }
}
