using UnityEngine;

public class FondoMovimiento : MonoBehaviour
{
    [SerializeField] private Vector2 velocidadFondo;
    private Vector2 offset;
    private Material material;
    private Rigidbody jugadorRB;
        
    private void Awake()
    {
        material = GetComponent<Renderer>().material;
        jugadorRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }

    private void Update()
    {
        offset = (jugadorRB.linearVelocity.x * 0.1f) * velocidadFondo * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
