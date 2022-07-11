using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    //timer
    [SerializeField] private float timer;
    [SerializeField] private float timerMax = 3f;
    [SerializeField] private float timerMin = 1.2f;


    //meu obstaculo
    [SerializeField] private GameObject obstaculo;

    //posição para criar obstaculo
    [SerializeField] private Vector3 posicao;

    //posicao minima  e maxima
    [SerializeField] private float posMin = -0.3f;
    [SerializeField] private float posMax = 2.4f;


    //variavel dos pontos
    private float pontos = 0;

    //variavel dos pontos canvas
    [SerializeField] private Text pontosTexto;

    //variavel do level
    private int level = 1;
    [SerializeField] private Text levelTexto;

    //variavel para ganhar level
    [SerializeField] private float proximoLevel = 10;


    //variavel do level up som
    [SerializeField] private AudioClip levelUpSound;

    //variavel da posição da maincamera
    private Vector3 camPos;

    

    void Start()
    {
        //pegando a posição da main camera
        camPos = Camera.main.transform.position;
    }

    
    void Update()
    {
        

        GanhaLevel();


        Pontos();

        CriaObstaculo();
    }

    private void CriaObstaculo()
    {
        timer -= Time.deltaTime;

        
        if (timer <= 0)
        {


            //resetando o timer
            timer = Random.Range(timerMin / level, timerMax);


            posicao.y = Random.Range(posMax, posMin);

            //criando os obstaculos
            Instantiate(obstaculo, posicao, Quaternion.identity);

        }
    }
    

    //metodo de ganhar pontos
    private void Pontos()
    {
        //ganhando pontos
         pontos = pontos + Time.deltaTime * level;

        //passando pontos para textPontos
        pontosTexto.text = Mathf.Round(pontos).ToString();

        

        
    }

    //passando de level
    private void GanhaLevel()
    {
        

        //passando level para o texto do level
        levelTexto.text = level.ToString();


        //se os pontos forem maiores que o proximo level, então eu aumento o valor do level
        // para o proximo level
        if (pontos > proximoLevel)
        {
           


            //som ao levelup
            AudioSource.PlayClipAtPoint(levelUpSound, camPos );
            

            //aumentando o level em 1
            level++;

            //dobrando o valor do proximo level
            proximoLevel *=  2;

            

        }

      
    }
    //criando um metodo para retornar o level
    public int RetornaLevel()
    {
        return level;
    }
}
