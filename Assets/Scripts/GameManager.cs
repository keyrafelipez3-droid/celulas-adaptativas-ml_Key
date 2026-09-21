using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public CellSpawner spawner;
    public CellBrain brain;
    public ScoreManager scoreManager;

    public float duracionRonda = 10f;
    public int totalRondas = 10;
    private bool rondaActiva = false;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        StartCoroutine(JugarPartida());
    }

    IEnumerator JugarPartida()
    {
        for (int ronda = 1; ronda <= totalRondas; ronda++)
        {
            yield return StartCoroutine(JugarRonda());
        }
        // Al terminar todas las rondas, avisamos al jugador en pantalla.
        scoreManager.textoPuntaje.text = "¡Juego terminado! Puntaje final: " + scoreManager.puntaje;
        Debug.Log("Juego terminado. Puntaje final: " + scoreManager.puntaje);
    }
    IEnumerator JugarRonda()
    {
        rondaActiva = true;
        spawner.GenerarRonda();

        float tiempoRestante = duracionRonda;
        while (tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;
            yield return null;
        }

        rondaActiva = false;

        foreach (CellController celula in spawner.ObtenerCelulasActivas())
        {
            if (celula != null && !celula.eliminada)
            {
                brain.RegistrarSobreviviente(celula.cellColor, celula.cellSize);
            }
        }
    }
    // Llamado desde CellController cuando el jugador hace clic en una célula.
    public void CelulaClickeada(CellController celula)
    {
        if (!rondaActiva) 
        {
            return;
        }

        scoreManager.SumarPuntos(10);
        spawner.QuitarCelula(celula);
        Destroy(celula.gameObject);
    }
}