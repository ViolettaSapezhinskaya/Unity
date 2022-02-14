using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//стрельба игрока
public class ShootPlayer : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bomb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //выпускает пули при нажатии x
        if(Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(bullet, transform.position+new Vector3(0,20,0), transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(bomb, transform.position + new Vector3(0, 20, 0), transform.rotation);

        }

    }
}
