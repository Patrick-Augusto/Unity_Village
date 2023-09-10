using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoDoPlayer : MonoBehaviour
{
    public float velocidadeMovimento = 30.0f; 
    public float velocidadeRotação = 2.0f; 
    private float rotacaoX = 0;
    public float sensibilidadeMouse = 2.0f;
    private Quaternion rotacaoInicial; 

    private void Start()
    {
       
        rotacaoInicial = Camera.main.transform.localRotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Camera.main.transform.localRotation = rotacaoInicial;
        }
        
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadeMouse;
        rotacaoX -= Input.GetAxis("Mouse Y") * sensibilidadeMouse;
        rotacaoX = Mathf.Clamp(rotacaoX, -90, 90);

        
        Camera.main.transform.localRotation = Quaternion.Euler(rotacaoX, 0, 0);
        transform.Rotate(Vector3.up * mouseX);

        
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

        
        Vector3 movimento = new Vector3(movimentoHorizontal, 0.0f, movimentoVertical) * velocidadeMovimento * Time.deltaTime;

   
        float rotacaoHorizontal = Input.GetAxis("Mouse X") * velocidadeRotação;
        transform.Rotate(Vector3.up * rotacaoHorizontal);

  
        transform.Translate(movimento);
    }
}
