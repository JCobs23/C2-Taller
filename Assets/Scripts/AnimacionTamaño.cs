using UnityEngine;

public class AnimacionTamaño : MonoBehaviour
{
    private Vector3 escalaOriginal;
    private float duracion = 1f;
    private float factorEscala = 1.5f;

    void Start()
    {
        escalaOriginal = transform.localScale;
    }

    void Update()
    {
        float factor = Mathf.PingPong(Time.time / duracion, 2f) * (factorEscala - 1f) + 1f;
        transform.localScale = escalaOriginal * factor;
    }
}
