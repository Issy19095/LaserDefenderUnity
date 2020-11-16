using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing2 : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float enemyMoveSpeed = 2f;

    int waypointIndex = 0;
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    void Update()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            targetPosition.z = 0f;
            var enemyMovement = enemyMoveSpeed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, enemyMovement);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
