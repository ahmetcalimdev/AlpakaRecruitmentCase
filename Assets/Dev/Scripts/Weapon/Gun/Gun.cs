using UnityEngine;

public class Gun : MonoBehaviour
{
    private float baseBulletPerSecond = 3f;
    private float bulletPerSecond;
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

    private int gunAttackRateUpgradeLevel = 1;
    private int gunAttackSpeedUpgradeLevel = 1;
    private float speedMultiplier = 1.1f;
    private float bulletRateMultiplier = 1.05f;

    private void Start()
    {
        UpdateGunStats();
    }
    private void OnEnable()
    {

        UpdateGunStats();
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


    private void UpdateGunStats()
    {
        gunAttackSpeedUpgradeLevel = UpgradeManager.Instance.GetUpgradeLevel(UpgradeType.GunAttackSpeed);
        gunAttackRateUpgradeLevel = UpgradeManager.Instance.GetUpgradeLevel(UpgradeType.GunAttackRate);
        shootingSpeed *= Mathf.Pow(speedMultiplier, gunAttackSpeedUpgradeLevel - 1);
        bulletPerSecond = baseBulletPerSecond * Mathf.Pow(bulletRateMultiplier, gunAttackRateUpgradeLevel - 1);
        shootInterval = 1f / bulletPerSecond;
    }
}
