using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlador : MonoBehaviour

{

    public float velocity = 10;
    Vector3 direcao;
    public LayerMask floorMask;
    public GameObject TextoGameOver;
    public bool live = true;
   

    public void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {


        //Inputs do Jogador - Guardando teclas apertadas
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX, 0, eixoZ);

        //Animações do Jogador
        if (direcao != Vector3.zero)
        {
            GetComponent<Animator>().SetBool("Moving", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Moving", false);
        }

        if(live == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("game");
            }
        }
    }

    void FixedUpdate()
    {
        //Movimentação do Jogador por segundo
        GetComponent<Rigidbody>().MovePosition
             (GetComponent<Rigidbody>().position + 
             (direcao * velocity * Time.deltaTime));

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        RaycastHit impact;

        if(Physics.Raycast(raio, out impact, 100, floorMask))
        {
            Vector3 positionSightPlayer = impact.point - transform.position;

            positionSightPlayer.y = transform.position.y;

            Quaternion newRotation = Quaternion.LookRotation(positionSightPlayer);

            GetComponent<Rigidbody>().MoveRotation(newRotation);
        }
    }
}
