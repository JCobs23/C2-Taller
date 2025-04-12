using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIVidaManager : MonoBehaviour
{
    public List<Image> corazones; // Lista de imagenes de corazones

    public void ActualizarVidas(int vidasRestantes)
    {
        for (int i = 0; i < corazones.Count; i++)
        {
            corazones[i].enabled = i < vidasRestantes;
        }
    }
}
