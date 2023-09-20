using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemy : MonoBehaviour
{
    public GameObject Personagens;
    public float velocity = 5;
    // Start is called before the first frame update
  

    void Start()
    {
        Personagens = GameObject.FindWithTag("Player");
        int generatorTypeZombie = Random.Range(1, 28);
        transform.GetChild(generatorTypeZombie).gameObject.SetActive(true);
    }

    void FixedUpdate()
    {

        float distancia = Vector3.Distance(transform.position, Personagens.transform.position);

        Vector3 direcao = Personagens.transform.position - transform.position;

        Quaternion newRotation = Quaternion.LookRotation(direcao);
        GetComponent<Rigidbody>().MoveRotation(newRotation);

        if (distancia > 2.5)
        {
           
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direcao.normalized * velocity * Time.deltaTime);
            GetComponent<Animator>().SetBool("Atacking", false);

        }
        else
        {
            GetComponent<Animator>().SetBool("Atacking", true);
        }
    }

    void AtacandoJogador()
    {
        Time.timeScale = 0;
        Personagens.GetComponent<controlador>().TextoGameOver.SetActive(true);
        Personagens.GetComponent<controlador>().live = false;
    }
}
