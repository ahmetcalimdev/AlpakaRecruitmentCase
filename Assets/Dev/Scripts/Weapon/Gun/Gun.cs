using UnityEngine;

public class Gun : MonoBehaviour
{
    public float bulletPerSecond = 1f;
    public float shootingRange;
    public float shootingSpeed;
    public float damagePerBullet;

    [SerializeField]
    private BulletPool pool;
    [SerializeField]
    private Transform bulletSpawnTransform;
    [SerializeField]
    private ParticleSystem _muzzleEffect;

    private bool isShooting = false;
    private float timeSinceLastShot = 0f;
    private float shootInterval;

    private void Start()
    {
        shootInterval = 1f / bulletPerSecond;
    }

    private void Update()
    {
        if (isShooting)
        {
            timeSinceLastShot += Time.deltaTime;

            if (timeSinceLastShot >= shootInterval)
            {
                Shoot();
                timeSinceLastShot = 0f;
            }
        }
    }

    public void StartShooting()
    {
        isShooting = true;
        timeSinceLastShot = shootInterval;
    }

    public void StopShooting()
    {
        isShooting = false;
    }

    private void Shoot()
    {
        Bullet bullet = pool.Dequeue();
        _muzzleEffect.Play();
        bullet.transform.position = bulletSpawnTransform.position;
        bullet.Init(damagePerBullet);
        bullet.ApplyForce(-bulletSpawnTransform.up, shootingSpeed);
    }
}
