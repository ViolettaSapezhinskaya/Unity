using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//движение вперед без физики
public class MoveForward : MonoBehaviour
{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //движение вперед с определенной скоростью
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
