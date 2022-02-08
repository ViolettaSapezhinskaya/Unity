using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    Vector3 start;
    public float distance = 120;
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

}
