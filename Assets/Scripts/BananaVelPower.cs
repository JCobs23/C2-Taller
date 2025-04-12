using UnityEngine;

public class BananaVelPower : MonoBehaviour
{
    public float velocidadExtra = 2f;
    [SerializeField] private AudioClip audioClipGema;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si colisiona con el jugador
        MovemPlayer jugador = collision.GetComponent<MovemPlayer>();
        if (jugador != null)
        {
            jugador.velocidad += velocidadExtra;
            ControladorSonido.Instance.EjecutarSonido(audioClipGema);
            Destroy(gameObject); // Destruye la banana
        }
    }
}
