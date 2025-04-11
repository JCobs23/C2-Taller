using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIVidaManager : MonoBehaviour
{
    public List<Image> corazones; // Lista de im�genes de corazones

    // Llam� a este m�todo desde tu script del jugador cuando pierda vida
    public void ActualizarVidas(int vidasRestantes)
    {
        for (int i = 0; i < corazones.Count; i++)
        {
            corazones[i].enabled = i < vidasRestantes;
        }
    }
}
