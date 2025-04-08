using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoporteObj : MonoBehaviour
{
    public GameObject childObject; // Referencia al objeto hijo (la gema)

    void Update()
    {
        // Verificar si el objeto hijo ha sido destruido
        if (childObject == null)
        {
            Destroy(gameObject); // Destruir el objeto padre
        }
    }
}