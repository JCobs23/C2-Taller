using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Necesario para cargar escenas
using System.Collections; // Necesario para corrutinas

public class LLaveFinal : MonoBehaviour
{
    public string sceneToLoad = "MenuGame";
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    [SerializeField] private GameObject panelFinal; // Panel que se activa al recoger la llave
    [SerializeField] private TextMeshProUGUI textoTiempo; // Texto para el tiempo total
    [SerializeField] private TextMeshProUGUI textoPuntuacion; // Texto para la puntuación
    [SerializeField] private TextMeshProUGUI textoFrutas; // Texto para las frutas recolectadas
    [SerializeField] private TextMeshProUGUI textoNombre;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();

        if (spriteRenderer != null && boxCollider != null)
        {
            spriteRenderer.enabled = false;
            boxCollider.enabled = false;
        }

        if (panelFinal != null)
        {
            panelFinal.SetActive(false);
        }
    }

    void Update()
    {
        if (GameManager.Instance.Score >= 100)
        {
            if (!spriteRenderer.enabled)
            {
                spriteRenderer.enabled = true;
                boxCollider.enabled = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Algo tocó la llave: " + collision.name);

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Es el jugador");

            if (GameManager.Instance.Score >= 50)
            {
                Debug.Log("Puntaje correcto. Activando panel y textos...");
                ActivarPanelYTextos();
                StartCoroutine(CargarEscenaConRetraso());
            }
            else
            {
                Debug.Log("Puntaje incorrecto: " + GameManager.Instance.Score);
            }
        }
    }

    private void ActivarPanelYTextos()
    {
        if (panelFinal != null)
        {
            panelFinal.SetActive(true);
        }

        if (textoTiempo != null)
        {
            textoTiempo.gameObject.SetActive(true);
            textoTiempo.text = "Tiempo: " + GameManager.Instance.TiempoAcumulado.ToString("F2") + "s";
        }

        if (textoPuntuacion != null)
        {
            textoPuntuacion.gameObject.SetActive(true);
            textoPuntuacion.text = "Puntuación: " + GameManager.Instance.Score;
        }

        if (textoFrutas != null)
        {
            textoFrutas.gameObject.SetActive(true);
            textoFrutas.text = "Frutas: " + GameManager.Instance.ObjetosRec;
        }

        //if (textoNombre != null)
        //{
        //    textoNombre.gameObject.SetActive(true);
        //    textoNombre.text = "Jugador: " + BotonGuardarUsuario.Instance.;
        //}
    }

    private IEnumerator CargarEscenaConRetraso()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(sceneToLoad);
    }
}