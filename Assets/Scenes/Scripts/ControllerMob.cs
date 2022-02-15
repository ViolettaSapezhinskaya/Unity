using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class ControllerMob : MonoBehaviour
{
    [SerializeField] Transform[] PatrolPoint;
    public float speed = 15;
    public float speedRotate = 70;
    public float distance = 70;
    public float stopDistance = 200;

    public UnityAction End;

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
            if (Vector3.Distance(transform.position, player.transform.position)>distance)
            {
                Debug.Log(Vector3.Distance(transform.position, player.transform.position));
                agent.destination = player.transform.position;
                agent.stoppingDistance = distance;
            }
            else
            {
                agent.ResetPath();
            }
            if (Vector3.Distance(start, transform.position) > stopDistance)
            {
                BattleEnd();
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!battle)
            {
                agent.ResetPath();
                battle = true;
                start = transform.position;
                player = other.gameObject;
            }
        }
    }
    private void SetPatrolPoint()
    { 
            if ((!agent.pathPending) && agent.remainingDistance <= .5f && PatrolPoint.Length!=0)
            {
                var dest = PatrolPoint[pointIndex % PatrolPoint.Length].position;
                agent.destination = dest;
                pointIndex++;
            }
    }
    private void BattleEnd()
    {
        End.Invoke();
        agent.ResetPath();
        battle = false;
        agent.stoppingDistance = .5f;

    }
    private void LookAtXZ(Vector3 point, float speed)
    {
        var direction = (point - transform.position).normalized;
        direction.y = 0f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), speed);
    }
}
