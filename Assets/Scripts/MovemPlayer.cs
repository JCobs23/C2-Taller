using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;


public class MovemPlayer : MonoBehaviour
{
    Rigidbody2D rigiBodyPlayer;
    public float velocidad = 3;
    public float fuerzaSalto = 5;
    [SerializeField] private AudioClip audioClipSalto;


    void Start()
    {
        rigiBodyPlayer = GetComponent<Rigidbody2D>(); // Fix: Assign the Rigidbody2D to the class-level variable
    }

    void Update()
    {
        ProcesarMovimiento();
        VoltearJugador();

        if (GetComponent<Rigidbody2D>().linearVelocity.x == 0) //si esta quieto 
        {
            GetComponent<Animator>().SetBool("caminando", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("caminando", true);
        }

        GetComponent<Animator>().SetFloat("velocidadY", GetComponent<Rigidbody2D>().linearVelocity.y); 

        if (GetComponent<Rigidbody2D>().linearVelocity.y == 0) //si esta en el suelo 
        {
            GetComponent<Animator>().SetTrigger("enSuelo");
        }
    }


    void ProcesarMovimiento()
    {
        float inputMovimiento = Input.GetAxisRaw("Horizontal");

        rigiBodyPlayer.linearVelocity = new Vector2(inputMovimiento * velocidad, rigiBodyPlayer.linearVelocity.y); // Fix: Corrected property name to 'velocity'
    }

    void VoltearJugador()
    {
        float inputMovimiento = Input.GetAxisRaw("Horizontal");

        if (inputMovimiento > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Voltear a la derecha
        }
        else if (inputMovimiento < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Voltear a la izquierda
        }
    }

    void ProcesarSalto()
    {
        if (GetComponent<Rigidbody2D>().linearVelocity.y == 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                ControladorSonido.Instance.EjecutarSonido(audioClipSalto);

                GetComponent<Rigidbody2D>().linearVelocity = new Vector2(GetComponent<Rigidbody2D>().linearVelocity.x, fuerzaSalto);
            }
        }
    }

    private void FixedUpdate()
    {
        ProcesarSalto();
    }
}
