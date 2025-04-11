using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIVidaManager : MonoBehaviour
{
    public List<Image> corazones; // Lista de imágenes de corazones

    // Llamá a este método desde tu script del jugador cuando pierda vida
    public void ActualizarVidas(int vidasRestantes)
    {
        for (int i = 0; i < corazones.Count; i++)
        {
            corazones[i].enabled = i < vidasRestantes;
        }
    }
}
