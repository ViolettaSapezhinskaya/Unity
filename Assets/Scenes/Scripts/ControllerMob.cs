using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControllerMob : MonoBehaviour
{
    [SerializeField] Transform[] PatrolPoint;
    public float speed = 15;
    public float speedRotate = 70;
    public float distancePlayer = 100;

    private int pointIndex;
    private NavMeshAgent agent;
    private bool battle = false;
    private Vector3 start;
    private GameObject player;
    private float rotZ;
   
    //ИИ противников
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!(battle))
        {
            SetPatrolPoint();

        }
        if (battle)
        {
            LookAtXZ(player.transform.position, speedRotate);
            if ((player.transform.position - transform.position).magnitude >= distancePlayer)
            {
                Go();
            }
            if (Vector3.Distance(transform.position,start)>200)
            {
                agent.destination = start;
            }
  
        }

    }
    void SetPatrolPoint()
    { 
            if ((!agent.pathPending) && agent.remainingDistance <= .5f && PatrolPoint.Length!=0)
            {
                var dest = PatrolPoint[pointIndex % PatrolPoint.Length].position;
                agent.destination = dest;
                pointIndex++;
            }
    }
    void Go()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed * 1);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            StopAllCoroutines();
            battle = true;
            start = transform.position;
            player = other.gameObject;
        }
    }
    private void LookAtXZ(Vector3 point, float speed)
    {
        var direction = (point - transform.position).normalized;
        direction.y = 0f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), speed);
    }
}
