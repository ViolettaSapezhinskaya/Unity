using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//игрок
public class Player : MonoBehaviour
{
    public int healthMax=100;
    public int healthFact = 100;
    public int damage = 25;
    private bool batle = false;
    private int key = 0;
    private int killMobs = 0;
    public int mobs = 4;

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
        //победа при уничтожении всех мобов на сцене
        if (killMobs>mobs)
        {
            Debug.Log("Winner");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //здоровье 0, при контакте с бомбой
        if (gameObject.CompareTag("Bomb"))
        {
            healthFact = 0;
        }
        //при контакте с пулей врагов здоровье -10
        //реализовать считывание урона пули
        if (gameObject.CompareTag("Bullet"))
        {
            healthFact -= 10;
        }
        //редим в бою, если рядом моб
        //реализовать,если рядом исчез моб mobs+1,счетчик убитых 
        if (gameObject.CompareTag("Mobs"))
        {
            batle = true;
        }
        //увелечение максимального здоровья при подходе к бонусу + уничтожение бонуса
        //реалитзовать считывание бонус здоровья или бонус атаки (может броню)
        if (gameObject.CompareTag("Bonus"))
        {
            healthMax += 50;
            Destroy(other.gameObject);
        }
        //при нахождении ключа
        if (gameObject.CompareTag("Key"))
        {
            key += 1;
        }
        //уничтожить дверь, если есть ключ
        if (gameObject.CompareTag("Mystery"))
        {
            if (key > 1)
            {
                //реализовать не уничтожение, а открытие двери
                Destroy(other.gameObject);
            }
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
