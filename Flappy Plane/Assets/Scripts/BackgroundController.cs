using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundController : MonoBehaviour
{
    //pegando meu material

    private Renderer meuFundo;

    //posição do x offset
    private float xOffset = 0f;

    //posição da minha textura
    private Vector2 texturaOffset;

    //velocidade da textura
    [SerializeField] private float velocidadeText = 0.1f;

    
    void Start()
    {
        //pegando meuFundo

        meuFundo = GetComponent<Renderer>();



    }

    
    void Update()
    {
        //diminuindo o valor do xOffset
        xOffset += velocidadeText * Time.deltaTime;



        //passando o xOffset para o eixo x da minha textura

        texturaOffset.x = xOffset;


        //movendo o offset x do meu renderer
        meuFundo.material.mainTextureOffset = texturaOffset;
        
    }
}
