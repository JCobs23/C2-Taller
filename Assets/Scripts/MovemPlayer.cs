using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class MovemPlayer : MonoBehaviour
{
    public GameObject BulletPrefab;
    Rigidbody2D rigiBodyPlayer;
    public float velocidad = 3;
    public float fuerzaSalto = 5;
    [SerializeField] private AudioClip audioClipSalto;
    public float radioCirculo;
    public Vector2 posicionCirculo;

    void Start()
    {
        rigiBodyPlayer = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ProcesarMovimiento();
        VoltearJugador();

        if (rigiBodyPlayer.linearVelocity.x == 0)
        {
            GetComponent<Animator>().SetBool("caminando", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("caminando", true);
        }

        GetComponent<Animator>().SetFloat("velocidadY", rigiBodyPlayer.linearVelocity.y);

        if (rigiBodyPlayer.linearVelocity.y == 0)
        {
            GetComponent<Animator>().SetTrigger("enSuelo");
        }
    }

    void ProcesarMovimiento()
    {
        float inputMovimiento = Input.GetAxisRaw("Horizontal");
        rigiBodyPlayer.linearVelocity = new Vector2(inputMovimiento * velocidad, rigiBodyPlayer.linearVelocity.y);
    }

    void VoltearJugador()
    {
        float inputMovimiento = Input.GetAxisRaw("Horizontal");
        if (inputMovimiento > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (inputMovimiento < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void ProcesarSalto()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (rigiBodyPlayer.linearVelocity.y == 0)
            {
                ControladorSonido.Instance.EjecutarSonido(audioClipSalto);
                rigiBodyPlayer.linearVelocity = new Vector2(rigiBodyPlayer.linearVelocity.x, fuerzaSalto);
            }

            Shoot();
        }
    }

    private void Shoot()
    {
        Vector2 direction;

        if (transform.localScale.x > 0)
            direction = Vector2.right;
        else
            direction = Vector2.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + (Vector3)(direction * 0.5f), Quaternion.identity);
        bullet.GetComponent<BulletScrip>().SetDirection(direction);
    }

    private void FixedUpdate()
    {
        ProcesarSalto();
    }
}
