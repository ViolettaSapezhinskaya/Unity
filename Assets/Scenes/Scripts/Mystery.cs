using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//открытие двери, если у игрока есть ключ
public class Mystery : MonoBehaviour
{
    public int key = 0;


    private int doorKey = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Key")
        {
            key += 1;
        }
        //уничтожение двери, если у игрока есть ключ
        if (other.tag=="Door" && key==doorKey)
        {
            Destroy(other.gameObject);
        }
    }
}
