using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//победа при убийстве всех противников
public class Winner : MonoBehaviour
{
    public int mobsInLevel = 4;
    public int killMobs = 0;

    private GameObject mobs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mobs.GetComponent<MobHealth>().kill += kils;
        if (killMobs>mobsInLevel)
        {
            Debug.Log("Winner!!!");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Mobs")
        {
            mobs = other.gameObject;
        }
    }
    void kils()
    {
        killMobs += 1;
    }

}
