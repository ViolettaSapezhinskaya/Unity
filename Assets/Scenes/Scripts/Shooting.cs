using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public class Shooting : MonoBehaviour
{
    public float indent = 5.0f;
    public float interval = 2.0f;
    public GameObject bullet;
    private bool sh = false;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ShootPlayer()
    {
        //исполнение функции через определенный интервал
        //??Почему-то выпускает 4 шара, а затем большой промежуток
        InvokeRepeating("Shoot", indent, interval);
    }
    
    void Shoot()
    {
        //выпускает шар 
        Instantiate(bullet, transform.position + new Vector3(0, 24, 0), transform.rotation);
    }
    private void OnTriggerEnter(Collider other)
    {
        //когда кто-то подходит исполняет функцию
        if (gameObject.CompareTag("Player"))
        {
            ShootPlayer();
        }
    }
    
}
