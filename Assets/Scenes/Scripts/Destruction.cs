using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//уничтожение пули
public class Destruction : MonoBehaviour
{
    public float distance = 120;

    Vector3 start;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //разрушает объект, когда тот пролетает определенное расстояние
        if (Vector3.Distance(start, transform.position)>distance)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            Destroy(gameObject);
        }
    }

}
