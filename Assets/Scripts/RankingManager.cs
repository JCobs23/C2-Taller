using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class RankingManager : MonoBehaviour
{
    public GameObject rankingPanel;
    public TMP_Text textoFrutas;
    public TMP_Text textoPuntuacion;
    public TMP_Text textoTiempo;
    public Button botonReiniciar;
    public TMP_Text textoNombre;


    void Start()
    {
        rankingPanel.SetActive(false);
        botonReiniciar.onClick.AddListener(ReiniciarDesdeCero);
    }

    public void MostrarRanking(int frutas, int puntuacion, float tiempo)
    {
        Time.timeScale = 0f;
        rankingPanel.SetActive(true);

        textoFrutas.text = frutas.ToString();
        textoPuntuacion.text = puntuacion.ToString();
        textoTiempo.text = tiempo.ToString("F2") + "s";

        // Crear y llenar datos del jugador
        DatosJugador datos = new DatosJugador();
        datos.nombre = BotonGuardarUsuario.nombreJugadorGuardado;
        datos.objetosRecolectados = frutas;
        datos.puntuacion = puntuacion;
        datos.tiempoRecorrido = tiempo;

        // Mostrar nombre
        textoNombre.text = datos.nombre;

        // DEBUG: imprimir valores para verificar
        Debug.Log("Guardando datos:");
        Debug.Log("Nombre: " + datos.nombre);
        Debug.Log("Frutas: " + datos.objetosRecolectados);
        Debug.Log("Puntuacion: " + datos.puntuacion);
        Debug.Log("Tiempo: " + datos.tiempoRecorrido);

        // Guardar JSON
        string json = JsonUtility.ToJson(datos, true);
        Debug.Log("JSON final generado:\n" + json); // <-- Mira esto en consola
        string rutaArchivo = Application.persistentDataPath + "/jugador.json";
        System.IO.File.WriteAllText(rutaArchivo, json);
    }


    public void ReiniciarDesdeCero()
    {
        Time.timeScale = 1f;

        // Borrar archivo de datos
        string rutaArchivo = Application.persistentDataPath + "/jugador.json";
        if (System.IO.File.Exists(rutaArchivo))
        {
            System.IO.File.Delete(rutaArchivo);
        }

        // Borrar nombre guardado
        BotonGuardarUsuario.nombreJugadorGuardado = "";

        // Cargar escena del menú
        SceneManager.LoadScene("MenuGame");
    }
}
