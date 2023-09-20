using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamera : MonoBehaviour
{
    public GameObject Personagens;
    Vector3 distCompensar;

    void Start()
    {
        distCompensar = transform.position - Personagens.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Personagens.transform.position + distCompensar;
    }
}
