using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//игрок
//реализовать через разные скрипты
public class Player : MonoBehaviour
{
    public int healthMax=100;
    public int healthFact = 100;

    private bool batle = false;

    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        //игра закончена, если здоровье равно 0
        if (healthFact==0)
        {
            Debug.Log("Game Over");
        }
        //Восстановление здоровья вне боя
        if ((healthFact < healthMax) && (batle == false))
        {
            //реализовать постепенное востановление здоровья
            healthFact = healthMax;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Bullet")
        {
            healthFact -= 5;
        }
        if(other.tag=="Bonus")
        {
            healthMax += 25;
        }
        if(other.tag=="Mobs")
        {
            batle = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //выключить режим боя при отходе от моба
        if (gameObject.CompareTag("Mobs"))
        {
            batle = false;
        }


    }
}
