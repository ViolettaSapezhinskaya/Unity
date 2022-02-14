using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerWithBomb : MonoBehaviour
{
    public float impuls = 50;



    private GameObject boom;
    Rigidbody Rb;
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Bomb")
        {
            boom = other.gameObject;
            boom.GetComponent<Boom>().bomb += Collaps;

        }
    }
    void Collaps()
    {
        Vector3 go = transform.position - boom.transform.position;
        Rb.AddForce(go * impuls, ForceMode.Impulse);
    }
}
