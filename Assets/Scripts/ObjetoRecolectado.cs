using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjetoRecolectado : MonoBehaviour
{
    public enum TipoObjeto
    {
        Manzana, Sandia, Uva, Banana, ManzanaVerde, Estrella, Curacion,Ninguno
    }

    public int valor = 5;
    public TipoObjeto objetoTipo = TipoObjeto.Ninguno;

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
            GameManager.Instance.RecolectarObjeto(valor, objetoTipo.ToString());
            ControladorSonido.Instance.EjecutarSonido(audioClipGema);
            Destroy(gameObject);
        }

        else if (objetoTipo == TipoObjeto.Curacion)
        {
            MovemPlayer jugador = collision.GetComponent<MovemPlayer>();
            if (jugador != null)
            {
                if (jugador.Vida < 5)
                {
                    jugador.Vida += 1;
                    Debug.Log($"Jugador curado. Vida actual: {jugador.Vida}");
                }
                else
                {
                    Debug.Log("Vida ya está al máximo, no se cura.");
                }
            }
        }
    }
}
