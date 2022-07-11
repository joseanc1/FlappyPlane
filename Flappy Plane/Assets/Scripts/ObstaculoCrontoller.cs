using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoCrontoller : MonoBehaviour
{

    //variavel de velocidade
    [SerializeField] private float velocidade = 4f;

    [SerializeField] private GameObject eu;

    //variavel do gamecontroller
    [SerializeField] private GameController game;


    void Start()
    {
        Destroy(eu, 5f);

        //encontrando o GameController da cena atual
        game = FindObjectOfType<GameController>();


        
            
    }


    void Update()
    {

        

        //indo para esquerda
        //transform.position = transform.position + Vector3.left  esse código é equivalente ao de baixo
        transform.position += Vector3.left * Time.deltaTime * velocidade;


        Debug.Log(game.RetornaLevel());


        velocidade = 4f+ game.RetornaLevel();
    }
}
