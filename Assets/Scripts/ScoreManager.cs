using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text textoPuntaje;
    public int puntaje = 0;

    public void SumarPuntos(int cantidad) 
    {
        puntaje += cantidad;
        textoPuntaje.text = "Puntos: " + puntaje;
    }
}
