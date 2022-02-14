using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//скрипт для бомбы
public class Bomba : MonoBehaviour
{
    
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
        //уничтожает объект при столкновении
        Destroy(other.gameObject);
    }
}
