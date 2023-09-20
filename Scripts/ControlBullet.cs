using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBullet : MonoBehaviour
{

    public GameObject Bullet;
    public GameObject Barrel;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Bullet, Barrel.transform.position, Barrel.transform.rotation);
        }
    }
}
