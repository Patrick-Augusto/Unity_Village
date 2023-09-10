using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Nuvens : MonoBehaviour
{
    public Vector3 posicaoInicial;
    public Vector3 posicaoFinal;
    public float velocidade = 3000.0f; // A velocidade de movimento do objeto.

    void Start()
    {
        posicaoInicial = new Vector3(-29, 65, 491f);
        posicaoFinal = new Vector3(-29, 65, -1051.9f);
        
    }

    void Update()
    {
        // Move o objeto em direção à posição final
        transform.position = Vector3.MoveTowards(transform.position, posicaoFinal, velocidade * Time.deltaTime);

        // Verifica se o objeto alcançou a posição final
        if (transform.position == posicaoFinal)
        {
            // Se sim, redefine a posição para a posição inicial
            transform.position = posicaoInicial;
        }
    }
}
