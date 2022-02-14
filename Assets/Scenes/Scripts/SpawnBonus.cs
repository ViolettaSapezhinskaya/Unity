using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//сундук выпускает бонус
public class SpawnBonus : MonoBehaviour
{
    public Transform[] Pos;
    public GameObject bonus;

    private int PosIndex;
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
        PosIndex = Random.Range(0, Pos.Length);
        //когда кто-то подходит, выпускает бонус и исчезает 
        if (other.tag=="Player")
        {
            Instantiate(bonus, Pos[PosIndex].transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
