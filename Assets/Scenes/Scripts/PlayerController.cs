using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float jump = 5;

    //скорость движения
    [SerializeField] float speed = 15;
    //скорость поворота
    [SerializeField] float turnSpeed = 120;


    private float horizontalInput;
    private float verticalInput;
    private float cameraInput;
    //есть ли пол
    private bool isGround = true;
    private Rigidbody Rb;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //считывание нажатий игрока
        horizontalInput =Input.GetAxis("Horizontal");
        verticalInput =Input.GetAxis("Vertical");
        //cameraInput = Input.GetAxis("Mouse X");
        //движение вперед-назад и влево-вправо
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Rotate(Vector3.up * Time.deltaTime*turnSpeed*horizontalInput);
        //transform.Rotate(Vector3.up, turnSpeed * cameraInput * Time.deltaTime);
        //прыжок при нажатии пробела
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Rb.AddForce(Vector2.up * jump, ForceMode.Impulse);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //на полу
        if (other.tag=="Ground")
        {
            isGround = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        //пола нет
        if (other.tag=="Ground")
        {
            isGround = false;
        }


    }
}
