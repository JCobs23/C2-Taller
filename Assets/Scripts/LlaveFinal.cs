using UnityEngine;

public class LlaveFinal : MonoBehaviour
{
    public RankingManager rankingManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Obtener datos del jugador desde el GameManager (o donde los tengas)
            int frutas = GameManager.Instance.ObjetosRec;
            int puntuacion = GameManager.Instance.Score;
            float tiempo = GameManager.Instance.TiempoAcumulado;

            // Llamar al método para mostrar el ranking
            rankingManager.MostrarRanking(frutas, puntuacion, tiempo);

            // Destruir llave o desactivarla si es necesario
            Destroy(gameObject);
        }
    }
}
