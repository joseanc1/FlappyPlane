using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InicioController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //checar se o espaço esta sendo pressionado
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //indo para cena do jogo
            SceneManager.LoadScene(1);
        }
    }
}
