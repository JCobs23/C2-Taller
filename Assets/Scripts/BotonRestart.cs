using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class BotonRestart : MonoBehaviour
{
    public void ReiniciarJuego()
    {
        // Borrar datos guardados
        string rutaArchivo = Application.persistentDataPath + "/jugador.json";
        if (File.Exists(rutaArchivo))
        {
            File.Delete(rutaArchivo);
            Debug.Log("Archivo de jugador eliminado.");
        }

        // Reiniciar GameManager
        GameManager.Instance.ResetScore();
        GameManager.Instance.ResetTiempo();

        // Reiniciar frutas (opcional)
        GameManager.Instance.ObjetosRec = 0;
        GameManager.Instance.BananasRec = 0;
        GameManager.Instance.ManzanasRojasRec = 0;
        GameManager.Instance.ManzanasVerdesRec = 0;
        GameManager.Instance.UvasRec = 0;
        GameManager.Instance.SandiasRec = 0;
        GameManager.Instance.PiñasRec = 0;
        GameManager.Instance.Curaciones = 0;

        // Ir a la escena del menú
        SceneManager.LoadScene("MenuGame");
    }
}
