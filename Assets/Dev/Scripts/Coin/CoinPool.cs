
public class CoinPool : ObjectPool<Coin>
{
    protected override void DequeueSettings(Coin pooledObject)
    {
        pooledObject.transform.SetParent(null);
        pooledObject.gameObject.SetActive(true);
    }
    protected override void EnqueueSettings(Coin pooledObject)
    {
        pooledObject.transform.SetParent(transform);
        pooledObject.gameObject.SetActive(false);
    }
}
