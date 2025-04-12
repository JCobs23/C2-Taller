using UnityEngine;

public class ObjetoRecolectado : MonoBehaviour
{
    public enum TipoObjeto
    {
        Manzana, Sandia, Uva, Banana, ManzanaVerde, Estrella, Curacion, Ninguno
    }

    public int valor = 5;
    public TipoObjeto objetoTipo = TipoObjeto.Ninguno;

    [SerializeField] private AudioClip audioClipGema;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        MovemPlayer jugador = collision.GetComponent<MovemPlayer>();

        if (jugador != null)
        {
            // Si es curación
            if (objetoTipo == TipoObjeto.Curacion)
            {
                if (jugador.Vida < 5)
                {
                    jugador.Vida += 1;
                    jugador.vidaUI.ActualizarVidas(jugador.Vida); 
                    Debug.Log($"Jugador curado. Vida actual: {jugador.Vida}");
                }
                else
                {
                    Debug.Log("Vida ya está al máximo, no se cura.");
                }
            }
            else
            {
                GameManager.Instance.RecolectarObjeto(valor, objetoTipo.ToString());
            }

            ControladorSonido.Instance.EjecutarSonido(audioClipGema);
            Destroy(gameObject); 
        }
    }
}
