using UnityEngine;

public class CicloDiaNoite : MonoBehaviour
{
    public Renderer rend; 
    public Material diaMaterial;
    public Material noiteMaterial;
    public float duracaoNoite = 15.0f; 
    public float duracaoDia = 18.3f;   

    private float tempoDecorrido = 0.0f;
    private bool eNoite = true;

    private void Start()
    {
        
        rend.material = noiteMaterial;
    }

    private void Update()
    {
        tempoDecorrido += Time.deltaTime;

        if (eNoite && tempoDecorrido >= duracaoNoite)
        {
            eNoite = false;
            tempoDecorrido = 0.0f;
            rend.material = diaMaterial; 
        }

        if (!eNoite && tempoDecorrido >= duracaoDia)
        {
            eNoite = true;
            tempoDecorrido = 0.0f;
            rend.material = noiteMaterial; 
        }

       
        if (tempoDecorrido >= (eNoite ? duracaoNoite : duracaoDia))
        {
            tempoDecorrido = 0.0f;
            eNoite = !eNoite; 
            rend.material = eNoite ? noiteMaterial : diaMaterial;
        }
    }
}
