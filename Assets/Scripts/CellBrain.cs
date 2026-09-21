using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CellBrain : MonoBehaviour
{
    public float mutationRate = 0.1f;
    public float minSize = 0.3f;
    public float maxSize = 1.5f;
    
    private List<Color> coloresSobrevivientes= new List<Color>();
    private List<float> tamanoSobreviviente= new List<float>();
    public void RegistrarSobreviviente(Color color, float tamano) 
    {
        coloresSobrevivientes.Add(color);
        tamanoSobreviviente.Add(tamano);
        if (coloresSobrevivientes.Count > 50) 
        {
            coloresSobrevivientes.RemoveAt(0);
            tamanoSobreviviente.RemoveAt(0);
        }
    }
    public Color GenerarColor() 
    {
        if (coloresSobrevivientes.Count == 0)
        {
            return new Color(Random.value, Random.value, Random.value);
        }
        int indice= Random.Range(0, coloresSobrevivientes.Count);
        Color colorBase = coloresSobrevivientes[indice];
        float r = Mathf.Clamp01(colorBase.r + Random.Range(-mutationRate, mutationRate));
        float g = Mathf.Clamp01(colorBase.g + Random.Range(-mutationRate, mutationRate));
        float b = Mathf.Clamp01(colorBase.b + Random.Range(-mutationRate, mutationRate));
        return new Color(r, g, b);

    }
    public float GenerarTamano()
    {
        if (tamanoSobreviviente.Count==0)
        {
            return Random.Range(minSize, maxSize);
        }
        int indice = Random.Range(0, tamanoSobreviviente.Count);
        float tamanoBase= tamanoSobreviviente[indice];
        float nuevoTamano = tamanoBase * (1 + Random.Range(-mutationRate, mutationRate));
        return Mathf.Clamp(nuevoTamano, minSize, maxSize);
    }
}
