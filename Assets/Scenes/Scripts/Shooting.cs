using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using UnityEngine.Events;

//стрельба противника
public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public float distance = 70;

    private GameObject player;
    private void Start()
    {
        gameObject.GetComponent<ControllerMob>().End += ShootingEnd;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.gameObject;
            if (Vector3.Distance(transform.position, player.transform.position) < distance)
            {
                StartCoroutine("ShootPlayer");
            }
        }
    }
    void Shoot()
    {
        //выпускает шар 
        Instantiate(bullet, transform.position + new Vector3(0, 24, 0), transform.rotation);
    }
    IEnumerator ShootPlayer()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(5);
        }
    }
    void ShootingEnd()
    {
        StopAllCoroutines();
    }
}
