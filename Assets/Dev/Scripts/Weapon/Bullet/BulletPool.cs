using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : ObjectPool<Bullet>
{
    protected override void DequeueSettings(Bullet pooledObject)
    {
        pooledObject.transform.SetParent(null);
        pooledObject.gameObject.SetActive(true);
    }

    protected override void EnqueueSettings(Bullet pooledObject)
    {
        pooledObject.transform.SetParent(transform);
        pooledObject.gameObject.SetActive(false);
    }
}
