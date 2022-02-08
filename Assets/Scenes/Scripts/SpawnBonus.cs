using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBonus : MonoBehaviour
{
    //реализовать спавн на разных  местах возле сундука
    //проблема с реализацией списка мест
    public GameObject Pos;
    public GameObject bonus;
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
        //когда кто-то подходит, выпускает бонус и исчезает 
        if (gameObject.CompareTag("Player"))
        {
            Instantiate(bonus, Pos.transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
