using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GemaRecolected : MonoBehaviour
{
    public int valor = 5;
    public float velocidadCambioEscala = 2f;

    [SerializeField] private AudioClip audioClipGema;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.SumValues(valor);
            ControladorSonido.Instance.EjecutarSonido(audioClipGema);
            Destroy(gameObject);
        }
    }
}
