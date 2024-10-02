using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolableObject<Bullet>
{
    public IObjectPool<Bullet> PoolParent { get; set; }
    [SerializeField]
    private Rigidbody _rb;
    private float _damage;
    private void OnEnable()
    {
        _rb.velocity = Vector3.zero;
        StartCoroutine(DisableAfterSeconds());
    }
    IEnumerator DisableAfterSeconds() 
    {
        yield return new WaitForSeconds(3f);
        PoolParent.Enqueue(this);
    }
    public void Init(float dmg) 
    {
        _damage = dmg;
    }
    public void ApplyForce(Vector3 direction, float force) 
    {
        transform.up = direction;
        _rb.AddForce(direction * force, ForceMode.Force);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            other.GetComponent<Enemy>().Damage(_damage);
            StopAllCoroutines();
            PoolParent.Enqueue(this);
        }
    }
}
