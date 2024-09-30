using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDistanceCheckable
{
    bool IsAggroed { get; set; }
    bool IsWithinAttackingDistance { get; set; }
    void SetAggroStatus(bool isAggroed);
    void SetAttackingDistance(bool isWithinAttackingDistance);
}
