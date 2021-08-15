using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoviment : MonoBehaviour
{

    public CharacterController2D controller;
    public float runSpeed = 40f;
    public Animator animator;
    public LayerMask chao;

    float horizantalMove = 0f;
    bool jump = false;
    int coins = 0;
    float Vida = 100;

    public Transform barraDeVida; //azul
    public GameObject barraDeVidaObj; //Objeto pai das barras
    private Vector3 barraDeVidaScale; //tamanho da barra 
    private float percentVida; //porcentual de vida


    // Start is called before the first frame update
    void Start()
    {
        barraDeVidaScale = barraDeVida.localScale;
        percentVida = barraDeVidaScale.x / Vida;
    }

    void upadateBarraDeVida()
    {   
        if(Vida > 0)
        {
            barraDeVidaScale.x = percentVida * Vida;
            barraDeVida.localScale = barraDeVidaScale;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vida > 0)
        {
            horizantalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            animator.SetFloat("Speed", Mathf.Abs(horizantalMove));

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                animator.SetBool("IsJumping", true);
            }
        }
        else { 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        }   
            
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if(coins == 13)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
          
    }

    void FixedUpdate()
    {
        controller.Move(horizantalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Colecionável"))
        {
            print("peguei");
            Destroy(collision.gameObject);
            coins++;
            print(coins);
        }

        if (collision.CompareTag("Enemy"))
        {
            Vida = Vida - 25;
            upadateBarraDeVida();
            if(Vida == 0)
            {
                animator.SetBool("Dead", true);
            }
            print("Ai");
        }
    }
}
