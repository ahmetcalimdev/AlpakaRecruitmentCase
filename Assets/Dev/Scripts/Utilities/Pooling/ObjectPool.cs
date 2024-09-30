using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour, IObjectPool<T>
        where T : MonoBehaviour, IPoolableObject<T>
{
    [Header("Poolable Object Prefab")]
    [SerializeField] private T pooledObjectPrefab;
    [Header("Pool Sizes")]
    [SerializeField] private int startSize;
    [SerializeField] private int maxSize;

    private Queue<T> queue = new Queue<T>();
    private int createdObjectCount;

    protected virtual void Awake()
    {
        for (int i = 0; i < startSize; i++)
        {
            CreatePoolObjectThenAddQueue();
        }
    }
    protected abstract void DequeueSettings(T pooledObject);
    protected abstract void EnqueueSettings(T pooledObject);
    protected virtual T CreatePoolObject()
    {
        return Instantiate(pooledObjectPrefab, transform);
    }
    private void CreatePoolObjectThenAddQueue()
    {
        T pooledObject = CreatePoolObject();
        pooledObject.PoolParent = this;
        Enqueue(pooledObject);
        createdObjectCount++;
    }
    public T Dequeue()
    {
        if (queue.Count == 0)
        {
            if (createdObjectCount < maxSize)
            {
                CreatePoolObjectThenAddQueue();
                return Dequeue();
            }
            return null;
        }
        T pooledObject = queue.Dequeue();
        DequeueSettings(pooledObject);
        return pooledObject;
    }
    public void Enqueue(T pooledObject)
    {
        EnqueueSettings(pooledObject);
        queue.Enqueue(pooledObject);
    }
}