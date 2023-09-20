using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZumbiGenerator : MonoBehaviour
{

    public GameObject Zombie;
    float counTime = 0;
    public float TimeGeneratorZombie;
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        counTime += Time.deltaTime;

        if(counTime >= TimeGeneratorZombie)
        {
            Instantiate(Zombie, transform.position, transform.rotation);
            counTime = 0;
        }
    }
}
