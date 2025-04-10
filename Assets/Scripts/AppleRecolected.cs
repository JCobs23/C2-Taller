using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GemaGenerador : MonoBehaviour
{
    public static GemaGenerador Instance;
    public GameObject gemaPrefab; // Prefab de la gema
    public Tilemap tilemap; // Referencia al Tilemap
    public int cantidadGemas;
    public int CantidadGemas { get => cantidadGemas; set => cantidadGemas = value; } // Propiedad para acceder a la cantidad de gemas


    void Start()
    {
        GenerarGemas();
    }

    void GenerarGemas()
    {
        BoundsInt bounds = tilemap.cellBounds; // Obtener los límites del Tilemap
        int gemasGeneradas = 0;

        while (gemasGeneradas < cantidadGemas)
        {
            // Generar una posición aleatoria dentro de los límites del Tilemap
            int x = Random.Range(bounds.xMin, bounds.xMax);
            int y = Random.Range(bounds.yMin, bounds.yMax);
            Vector3Int cellPosition = new Vector3Int(x, y, 0);

            // Convertir la posición de celda a posición del mundo
            Vector3 worldPosition = tilemap.CellToWorld(cellPosition) + new Vector3(0.5f, 0.5f, 0);

            // Ajustar la posición en Y sumando 2 unidades
            worldPosition.y += 5;

            // Verificar si la celda tiene un Tile (para evitar generar gemas fuera del mapa)
            if (tilemap.HasTile(cellPosition))
            {
                // Instanciar la gema en la posición calculada
                Instantiate(gemaPrefab, worldPosition, Quaternion.identity);
                gemasGeneradas++;
            }
        }
    }
}