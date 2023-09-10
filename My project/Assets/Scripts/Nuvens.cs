using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Nuvens : MonoBehaviour
{
    public Vector3 posicaoInicial;
    public Vector3 posicaoFinal;
    public float velocidade = 3000.0f; 

    void Start()
    {
        posicaoInicial = new Vector3(-29, 65, 491f);
        posicaoFinal = new Vector3(-29, 65, -1051.9f);
        
    }

    void Update()
    {
       
        transform.position = Vector3.MoveTowards(transform.position, posicaoFinal, velocidade * Time.deltaTime);

       
        if (transform.position == posicaoFinal)
        {
           
            transform.position = posicaoInicial;
        }
    }
}
