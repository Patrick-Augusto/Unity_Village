using UnityEngine;

public class CicloDiaNoite : MonoBehaviour
{
    public Renderer rend; // O componente Renderer do objeto com o material.
    public Material diaMaterial;
    public Material noiteMaterial;
    public float duracaoNoite = 15.0f; // Duração da noite (15 segundos).
    public float duracaoDia = 18.3f;   // Duração do dia (18.3 segundos).

    private float tempoDecorrido = 0.0f;
    private bool eNoite = true;

    private void Start()
    {
        // Inicialmente, definimos o material da noite.
        rend.material = noiteMaterial;
    }

    private void Update()
    {
        tempoDecorrido += Time.deltaTime;

        if (eNoite && tempoDecorrido >= duracaoNoite)
        {
            eNoite = false;
            tempoDecorrido = 0.0f;
            rend.material = diaMaterial; // Transição para o dia.
        }

        if (!eNoite && tempoDecorrido >= duracaoDia)
        {
            eNoite = true;
            tempoDecorrido = 0.0f;
            rend.material = noiteMaterial; // Transição para a noite.
        }

        // Verifica se o ciclo de dia e noite deve reiniciar.
        if (tempoDecorrido >= (eNoite ? duracaoNoite : duracaoDia))
        {
            tempoDecorrido = 0.0f;
            eNoite = !eNoite; // Alterna entre dia e noite.
            rend.material = eNoite ? noiteMaterial : diaMaterial;
        }
    }
}
