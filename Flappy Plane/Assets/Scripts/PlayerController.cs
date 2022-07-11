using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class PlayerController : MonoBehaviour
{
    //variaveis player

    private Rigidbody2D meuRB;

    //velocidade
    [SerializeField] private float velocidade = 5f;


    //minha posição

    private Vector3 meuY;


    //variavel puff
    [SerializeField] private GameObject puff;





    void Start()
    {
        //pegando o rb sozinho
        meuRB = GetComponent<Rigidbody2D>();

        
        
    }


    void Update()
    {
        Subir();


        LimitandoVelocidade();

        MorrendoAoSair();

        

    }

    private void LimitandoVelocidade()
    {

        //limitando a velocidade de queda
        if (meuRB.velocity.y < -velocidade)
        {
            //limitando meu meuRB.velocity.y em -5
            meuRB.velocity = Vector2.down * velocidade;
        }
    }

    //metodo subir
    public void Subir()
    {

       

        //ação de subir ao apertar espaço
        if (Input.GetKeyDown(KeyCode.Space))
        {

            //velocidade do rigibody ir para cima
            meuRB.velocity = Vector2.up * velocidade;

           
            
            //criando o puff - colocando a instancia (gameobject) do puff na memória do jogo
            //salvando a instancia criada em uma variavel
           GameObject meuPuf = Instantiate(puff, transform.position, Quaternion.identity);

            //destruindo meuPuf
            Destroy(meuPuf, 2f);

        }

       



    }

    //configurando colisão do player
    private void OnTriggerEnter2D(Collider2D collision)
    {



        Debug.Log("colidiu");

        //usando sceneManager, é preciso dar load na cena "Jogo"
        SceneManager.LoadScene(0);
    }

    //jogo reinicia se o y do player passar dos limites da tela
    private void MorrendoAoSair()
    {
        //se meu position Y for maior ou menor que 5.1 reload cena

        meuY = transform.position;


        //limitando descida e subida
        if (transform.position.y < -5.1f || transform.position.y > 5f)
        {
            SceneManager.LoadScene(0);
        }


    }
}
     
