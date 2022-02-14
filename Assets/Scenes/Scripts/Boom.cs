using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//скрипт движения вперед с помощью физики + взрыв
public class Boom : MonoBehaviour
{
    public float speed = 10;

    public UnityAction bomb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            bomb.Invoke();
        }


    }
}
