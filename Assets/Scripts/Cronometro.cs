using UnityEngine;
using System.Collections; // Importa el espacio de nombres necesario para las corrutinas
using System.Collections.Generic; // Importa el espacio de nombres necesario para las listas
using TMPro;

public class Cronometro : MonoBehaviour // Hereda de MonoBehaviour para que funcione en Unity
{
    [SerializeField] TextMeshProUGUI textoCronometro; // Corrige el atributo SerializeField
    [SerializeField] private float tiempo; // Corrige el atributo SerializeField y elimina "private" redundante

    private int tiempoMinutos, tiempoSegundos, tiempoMilisegundos;

    private void ActualizarCronometro() // Cambia el nombre del método para evitar conflicto con el nombre de la clase
    {
        tiempo += Time.deltaTime;
        tiempoMinutos = Mathf.FloorToInt(tiempo / 60);
        tiempoSegundos = Mathf.FloorToInt(tiempo % 60);
        tiempoMilisegundos = Mathf.FloorToInt((tiempo - (tiempoSegundos + tiempoMinutos * 60)) * 100);

        if (textoCronometro != null) // Verifica que textoCronometro no sea nulo
        {
            textoCronometro.text = string.Format("{0:00}:{1:00}:{2:00}", tiempoMinutos, tiempoSegundos, tiempoMilisegundos);
        }
    }

    private void Update() // Cambia "update" a "Update" para que Unity lo reconozca
    {
        ActualizarCronometro();
    }
}
