using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement; // ← Agregado para reiniciar la escena

public class MovemPlayer : MonoBehaviour
{
    public GameObject BulletPrefab;
    Rigidbody2D rigiBodyPlayer;
    public float velocidad = 3;
    public float fuerzaSalto = 5;
    [SerializeField] private AudioClip audioClipSalto;
    public float radioCirculo;
    public Vector2 posicionCirculo;
    public int vida = 3;
    public string shooterTag;
    public UIVidaManager vidaUI;

    void Start()
    {
        rigiBodyPlayer = GetComponent<Rigidbody2D>();

        if (vidaUI == null)
            vidaUI = FindObjectOfType<UIVidaManager>();

        if (vidaUI != null)
            vidaUI.ActualizarVidas(vida);
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

        if (Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
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
        }
    }

    public void RecibirDaño(int daño)
    {
        vida -= daño;
        Debug.Log("Vida restante: " + vida);

        // Actualizar corazones en pantalla
        if (vidaUI != null)
        {
            vidaUI.ActualizarVidas(vida);
        }

        if (vida <= 0)
        {
            Morir();
        }
    }

    public void Morir() 
    {
        Debug.Log("¡Jugador eliminado!");
        StartCoroutine(ReiniciarEscena());
    }

    IEnumerator ReiniciarEscena()
    {
        yield return new WaitForSeconds(1f); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetShooterTag(string tag)
    {
        shooterTag = tag;
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
        bullet.GetComponent<BulletScrip>().SetShooterTag("Player");
    }

    private void FixedUpdate()
    {
        ProcesarSalto();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (shooterTag == "Enemy" && other.CompareTag("Player"))
        {
            MovemPlayer player = other.GetComponent<MovemPlayer>();
            if (player != null)
            {
                player.RecibirDaño(1);
            }
            Destroy(gameObject);
        }

        if (shooterTag == "Player" && other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
