using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBonus : MonoBehaviour
{
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
        //int index = Random.Range(0, Pos.Length);
        Instantiate(bonus, Pos.transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
