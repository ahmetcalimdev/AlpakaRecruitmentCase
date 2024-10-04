
using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour, IPoolableObject<Coin>
{
    public int coinAmount;
    public IObjectPool<Coin> PoolParent { get; set; }
    private void OnEnable()
    {
        StartCoroutine(DestroyAfterSeconds());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            GameEvents.TriggerCoinEarned(this);
            PoolParent.Enqueue(this);
        }
    }
    IEnumerator DestroyAfterSeconds() 
    {
        yield return new WaitForSeconds(5f);
        PoolParent.Enqueue(this);
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
