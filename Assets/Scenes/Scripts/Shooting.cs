using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

//стрельба противника
public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public float pause = 5;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ShootPlayer()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(pause);
        }
    }
    
    void Shoot()
    {
        //выпускает шар 
        Instantiate(bullet, transform.position + new Vector3(0, 24, 0), transform.rotation);
    }
    private void OnTriggerEnter(Collider other)
    {
        //когда кто-то подходит исполняет функцию
        if (other.tag=="Player")
        {
            StartCoroutine("ShootPlayer");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="Player")
        {
            StopAllCoroutines();
        }
    }

}
