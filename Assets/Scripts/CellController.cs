using UnityEngine;

public class CellController : MonoBehaviour
{
    public Color cellColor;
    public float cellSize;
    public bool eliminada = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = cellColor;
        transform.localScale= new Vector3(cellSize, cellSize, 1);
    }
    void OnMouseDown()
    {
        if (eliminada)
        {
            return;
        }
        eliminada = true;
        GameManager.instance.CelulaClickeada(this);
    }
}
