using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LlaveDorada : MonoBehaviour
{
    public string sceneToLoad; // Nombre de la escena a cargar
    private SpriteRenderer spriteRenderer; // Referencia al SpriteRenderer del objeto

    void Start()
    {
        // Obtener el SpriteRenderer del objeto
        spriteRenderer = GetComponent<SpriteRenderer>();
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false; // Hacer el objeto invisible al inicio
            boxCollider.enabled = false; // Deshabilitar el BoxCollider al inicio
        }
        else
        {
            Debug.LogError("No se encontró un SpriteRenderer en el objeto.");
        }
    }

    void Update()
    {
        if (GameManager.Instance.Score == 50)
        {
            if (!spriteRenderer.enabled)
            {
                spriteRenderer.enabled = true; // Hacer visible el objeto
                GetComponent<BoxCollider2D>().enabled = true; // Habilitar el BoxCollider
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si el jugador colisiona con el objeto
        if (collision.CompareTag("Player") & GameManager.Instance.Score == 50)
        {
            SceneManager.LoadScene(sceneToLoad);
            Destroy(gameObject); 
        }
    }
}
