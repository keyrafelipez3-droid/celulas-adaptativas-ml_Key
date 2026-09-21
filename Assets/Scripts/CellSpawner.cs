using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CellSpawner : MonoBehaviour
{
    public GameObject cellPrefab;
    public CellBrain brain;
    public BoxCollider2D spawnArea;
    public int cantidadCelulas = 8;

    private List<CellController>celulasActivas= new List<CellController>();

    public void GenerarRonda()
    {
        BorrarCelulasAnteriores();

        for (int i = 0; i < cantidadCelulas; i++)
        {
            Vector2 posicion = PosicionAleatoria();
            GameObject nuevo = Instantiate(cellPrefab, posicion, Quaternion.identity);
            CellController celula = nuevo.GetComponent<CellController>();

            celula.cellColor = brain.GenerarColor();
            celula.cellSize = brain.GenerarTamano();

            celulasActivas.Add(celula);
        }
    }

    public List<CellController> ObtenerCelulasActivas()
    {
        return celulasActivas;
    }

    public void QuitarCelula(CellController celula)
    {
        celulasActivas.Remove(celula);
    }

    void BorrarCelulasAnteriores()
    {
        foreach (CellController celula in celulasActivas)
        {
            if (celula != null)
            {
                Destroy(celula.gameObject);
            }
        }
        celulasActivas.Clear();
    }

    Vector2 PosicionAleatoria()
    {
        Bounds area = spawnArea.bounds;
        float x = Random.Range(area.min.x, area.max.x);
        float y = Random.Range(area.min.y, area.max.y);
        return new Vector2(x, y);
    }
}
