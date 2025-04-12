using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnerObjetos : MonoBehaviour
{
    public static SpawnerObjetos Instance;
    public GameObject gemaPrefab; 
    public Tilemap tilemap; 
    public int cantidadGemas;
    public int CantidadGemas { get => cantidadGemas; set => cantidadGemas = value; } 


    void Start()
    {
        GenerarGemas();
    }

    void GenerarGemas()
    {
        BoundsInt bounds = tilemap.cellBounds; // Obtener los limites del Tilemap
        int objetosGenerados = 0;

        while (objetosGenerados < cantidadGemas)
        {
            // Generar una posición aleatoria dentro de los limites del Tilemap
            int x = Random.Range(bounds.xMin, bounds.xMax);
            int y = Random.Range(bounds.yMin, bounds.yMax);
            Vector3Int cellPosition = new Vector3Int(x, y, 0);

            // Convertir la posicion de celda a posicion del mundo
            Vector3 worldPosition = tilemap.CellToWorld(cellPosition) + new Vector3(0.5f, 0.5f, 0);

            // Ajustar la posición en Y sumando 2 unidades
            worldPosition.y += 5;

            // Verificar si la celda tiene un Tile (para evitar generar gemas fuera del mapa)
            if (tilemap.HasTile(cellPosition))
            {
                // Instanciar la gema en la posicion calculada
                Instantiate(gemaPrefab, worldPosition, Quaternion.identity);
                objetosGenerados++;
            }
        }
    }
}