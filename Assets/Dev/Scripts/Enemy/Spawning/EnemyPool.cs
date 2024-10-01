public class EnemyPool : ObjectPool<Enemy>
{
    protected override void DequeueSettings(Enemy pooledObject)
    {
        pooledObject.transform.SetParent(null);
        pooledObject.gameObject.SetActive(true);
    }

    protected override void EnqueueSettings(Enemy pooledObject)
    {
        pooledObject.transform.SetParent(transform);
        pooledObject.gameObject.SetActive(false);
    }

}
