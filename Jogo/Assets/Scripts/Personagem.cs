using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Personagem : MonoBehaviour
{
    public Rigidbody2D corpoPersonagem;
    public Transform posicaoDoPe;
    public Animator animator;

    public LayerMask chao;


    private float direcao;
    public float velocidade, ForcaDoPulo;
    private bool estaNoChao;

    public int coins;

    // Start is called before the first frame update
    void Start()
    {
        coins =  0;
    }

    // Update is called once per frame
    void Update()
    {
        
        estaNoChao = Physics2D.OverlapCircle(posicaoDoPe.position, 0.3f, chao);
        //<- = -1
        //-> = 1
        direcao = Input.GetAxisRaw("Horizontal");
        corpoPersonagem.velocity = new Vector2(direcao * velocidade, corpoPersonagem.velocity.y);


        if (estaNoChao && Input.GetKeyDown(KeyCode.Space))
        {
            corpoPersonagem.velocity = Vector2.up * ForcaDoPulo;
        }
        /*if (Input.GetKeyDown(KeyCode.Escape))        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }*/

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            print("Ai");
  

        }else if (collision.CompareTag("Colecionável"))
        {
            print("peguei");
            Destroy(collision.gameObject);
            coins++;
            print(coins);
        } 
        


    }
    
}
