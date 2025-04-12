using UnityEngine;
using UnityEngine.UI;

public class BotonGuardarUsuario : MonoBehaviour
{
    public GameObject panelUsuario;     // El panel que aparece para ingresar nombre
    public InputField inputNombre;      // InputField para el nombre
    public Button jugadorBoton;         // Botón para abrir el panel
    public Button botonGuardarUsuario;  // Botón para guardar el nombre

    public static string nombreJugadorGuardado = "";


    void Start()
    {
        panelUsuario.SetActive(false); // Oculta el panel al inicio

        jugadorBoton.onClick.AddListener(MostrarPanel);
        botonGuardarUsuario.onClick.AddListener(GuardarNombre);
    }

    void MostrarPanel()
    {
        panelUsuario.SetActive(true);
    }

    void GuardarNombre()
    {
        string nombre = inputNombre.text;

        if (!string.IsNullOrEmpty(nombre))
        {
            nombreJugadorGuardado = nombre;
            Debug.Log("Nombre guardado: " + nombreJugadorGuardado);
            panelUsuario.SetActive(false);  // Oculta el panel luego de guardar

            // Crear objeto con los datos del jugador
            DatosJugador datos = new DatosJugador();
            datos.nombre = nombre;
            datos.puntuacion = 0;
            datos.objetosRecolectados = 0;
            datos.tiempoRecorrido = 0;

            // Convertir a JSON y guardar en archivo
            string json = JsonUtility.ToJson(datos, true);
            string rutaArchivo = Application.persistentDataPath + "/jugador.json";
            System.IO.File.WriteAllText(rutaArchivo, json);

            Debug.Log("Datos del jugador guardados en: " + rutaArchivo);
        }
        else
        {
            Debug.LogWarning("¡Ingresa un nombre válido!");
        }
    }
}

