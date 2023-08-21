using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;
    public float arrivalDistance = 0.1f; // Дистанция, при которой считается, что объект достиг цели

    // Start is called before the first frame update
    void Start()
    {
        targetPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, patrolPoints[targetPoint].position);

        if (distanceToTarget <= arrivalDistance)
        {
            IncreaseTargetIndex();
        }

        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);
    }

    void IncreaseTargetIndex()
    {
        targetPoint = (targetPoint + 1) % patrolPoints.Length; // Циклическая смена точек патрулирования
    }
}
