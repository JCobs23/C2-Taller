using UnityEngine;
using UnityEngine.UI;

public class ControladorVolumen : MonoBehaviour
{
    public Button botonVolumen;
    public Sprite iconoOn; // Icono de volumen activo
    public Sprite iconoOff; // Icono de volumen apagado
    public Image imagenBoton; // Referencia a la imagen del botón

    private bool estaMuteado = false;

    void Start()
    {
        botonVolumen.onClick.AddListener(ToggleVolumen);
        ActualizarIcono();
    }

    void ToggleVolumen()
    {
        estaMuteado = !estaMuteado;
        AudioListener.volume = estaMuteado ? 0 : 1;
        ActualizarIcono();
    }

    void ActualizarIcono()
    {
        if (imagenBoton != null)
        {
            imagenBoton.sprite = estaMuteado ? iconoOff : iconoOn;
        }
    }
}
