using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //скорость движения
    [SerializeField] private float speed = 10;
    //скорость поворота
    [SerializeField] private float turnSpeed = 40;
    private float horizontalInput;
    private float verticalInput;
    //есть ли пол
    private bool isGround = true;
    public Rigidbody Rb;
    public float jump = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //считывание нажатий игрока
        horizontalInput =Input.GetAxis("Horizontal");
        verticalInput =Input.GetAxis("Vertical");
        
        //движение вперед-назад
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        //поворот камеры при нажатии a и d
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        //прыжок при нажатии пробела
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }
        int a = 0;
        while (a!=5)
        {
            Debug.Log(a);
            a += 1;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //на полу
        if (gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        //пола нет
        if (gameObject.CompareTag("Mobs"))
        {
            isGround = false;
        }


    }
}
