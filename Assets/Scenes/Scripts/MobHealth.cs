using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MobHealth : MonoBehaviour
{
    public float healthFact = 50;
    public UnityAction kill;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthFact<0)
        {
            kill.Invoke();
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Damage")
        {
            healthFact -= 15;
        }
    }
}
