using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoDoPlayer : MonoBehaviour
{
    public float velocidadeMovimento = 30.0f; // Velocidade de movimentação do jogador.
    public float velocidadeRotação = 2.0f; // Velocidade de rotação do jogador.
    private float rotacaoX = 0;
    public float sensibilidadeMouse = 2.0f;
    private Quaternion rotacaoInicial; // Declaração da variável de classe.

    private void Start()
    {
        // Armazena a rotação inicial da câmera.
        rotacaoInicial = Camera.main.transform.localRotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Camera.main.transform.localRotation = rotacaoInicial;
        }
        // Rotação da câmera usando o mouse.
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadeMouse;
        rotacaoX -= Input.GetAxis("Mouse Y") * sensibilidadeMouse;
        rotacaoX = Mathf.Clamp(rotacaoX, -90, 90);

        // Aplicar a rotação da câmera.
        Camera.main.transform.localRotation = Quaternion.Euler(rotacaoX, 0, 0);
        transform.Rotate(Vector3.up * mouseX);

        // Obtém os valores das teclas de entrada horizontal e vertical.
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

        // Calcula o vetor de movimento com base nas entradas de teclado.
        Vector3 movimento = new Vector3(movimentoHorizontal, 0.0f, movimentoVertical) * velocidadeMovimento * Time.deltaTime;

        // Rotaciona o jogador com base no movimento do mouse.
        float rotacaoHorizontal = Input.GetAxis("Mouse X") * velocidadeRotação;
        transform.Rotate(Vector3.up * rotacaoHorizontal);

        // Aplica o movimento ao jogador.
        transform.Translate(movimento);
    }
}
