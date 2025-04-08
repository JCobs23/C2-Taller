using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject panelAyuda;

    public void IniciarJuego()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("EsceneGame1");
    }

    public void MostrarAyuda()
    {
        panelAyuda.SetActive(true);
    }

    public void OcultarAyuda()
    {
        panelAyuda.SetActive(false);
    }

    public void SalirJuego()
    {
        Debug.Log("Saliendo...");
        Application.Quit();
    }

    public GameObject panelCreditos;

    public void MostrarCreditos()
    {
        panelCreditos.SetActive(true);
    }

    public void CerrarCreditos()
    {
        panelCreditos.SetActive(false);
    }


}