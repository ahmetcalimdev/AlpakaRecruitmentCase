using UnityEngine;
using UnityEngine.AI;
public interface IEnemyMoveable
{
    void Move(Vector3 destination);
    void Stop();
    NavMeshAgent NavMeshAgent { get; set; }
}
