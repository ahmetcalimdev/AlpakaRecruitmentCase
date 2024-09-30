using UnityEngine;
using UnityEngine.AI;
public interface IEnemyMoveable
{
    void Move(Vector3 destination);
    NavMeshAgent NavMeshAgent { get; set; }
}
