using UnityEngine;

public class Pinchos : MonoBehaviour
{
    public float fuerzaRebote = 5f;
    public float tiempoParaMorir = 0.5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            MovemPlayer jugador = collision.collider.GetComponent<MovemPlayer>();
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

            if (jugador != null && rb != null)
            {
    
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaRebote);

       
                jugador.enabled = false;

           
                jugador.StartCoroutine(MorirConRetraso(jugador, tiempoParaMorir));
            }
        }
    }

    private System.Collections.IEnumerator MorirConRetraso(MovemPlayer jugador, float delay)
    {
        yield return new WaitForSeconds(delay);
        jugador.Morir();
    }
}
