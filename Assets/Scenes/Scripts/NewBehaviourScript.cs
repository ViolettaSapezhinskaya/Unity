using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private float Speed = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var a = Input.GetAxis("Horizontal");
        var b = Input.GetAxis("Vertical");

        var direction = new Vector3(a, 0, b);
        //Задание позиции 1 раз
        //transform.position = transform.position + Speed *direction*Time.deltaTime;

        transform.Translate(Speed * direction * Time.deltaTime);
    }
}