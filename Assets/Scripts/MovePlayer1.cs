using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer1 : MonoBehaviour
{
    float horizontal;
    public float speed = 5f;

    private Rigidbody2D rigiBodyPlayer;

    public int fuerzaSalto = 10;
    public float longitudRaycast = 0.1f;
    public LayerMask capaSuelo;
    
    private bool enSuelo;
    public Transform controladorSuelo;
    public Vector3 dimensionesCaja;

    public Animator animator;

    [SerializeField] private AudioClip audioClipSalto;

    // Start is called before the first frame update
    void Start()
    {
        rigiBodyPlayer = GetComponent<Rigidbody2D>(); // Fix: Assign the Rigidbody2D to the class-level variable
    }

    // Update is called once per frame
    void Update()
    {
        ProcesarMovimiento();
        VoltearJugador();
        ProcesarSalto();
    }

    void ProcesarMovimiento()
    {
        float inputMovimiento = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("movimiento", Mathf.Abs(inputMovimiento));

        rigiBodyPlayer.linearVelocity = new Vector2(inputMovimiento * speed, rigiBodyPlayer.linearVelocity.y); // Fix: Corrected property name to 'velocity'
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
        bool enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, capaSuelo);
        if (enSuelo)
        {
            if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rigiBodyPlayer.linearVelocity.y) < 0.01f)
            {
                rigiBodyPlayer.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
                ControladorSonido.Instance.EjecutarSonido(audioClipSalto);

            }
        }

        animator.SetBool("saltando", !enSuelo); 
    }


    //private void FixedUpdate()
    //{
    //    enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, capaSuelo);
    //    animator.SetBool("saltando", enSuelo);
    //}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }

}
