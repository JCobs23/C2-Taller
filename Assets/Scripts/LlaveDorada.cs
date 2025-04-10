using UnityEngine;
using UnityEngine.SceneManagement;

public class LlaveDorada : MonoBehaviour
{
    public string sceneToLoad = "SceneGame2";
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();

        if (spriteRenderer != null && boxCollider != null)
        {
            spriteRenderer.enabled = false;
            boxCollider.enabled = false;
        }
    }

    void Update()
    {
        if (GameManager.Instance.Score >= 50)

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
                Debug.Log("Puntaje correcto. Cargando escena...");
                SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                Debug.Log("Puntaje incorrecto: " + GameManager.Instance.Score);
            }
        }
    }
}
