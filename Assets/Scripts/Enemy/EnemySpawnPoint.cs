using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    public List<Transform> GetPatrolPoints()
    {
        List<Transform> patrolPoints = new List<Transform>();
        int chiledAmount = transform.childCount;

        for (int i = 0; i < chiledAmount; i++)
        {
            Transform point = transform.GetChild(i);

            if (point.gameObject.TryGetComponent(out EnemyPatrolPoint component))
                patrolPoints.Add(point);
        }

        return patrolPoints;
    }
}
