using DG.Tweening;
using UnityEngine;

public class AuraSkill : MonoBehaviour
{
    [SerializeField]
    private Transform _trigger;
    [SerializeField]
    private ParticleSystem _auraEffect;

    private float nextActionTime = 0.0f;
    public float baseAttackInterval = 5f;
    public float baseDamageAmount = 250f;
    public float baseRadius = 1.5f;

    public int attackIntervalUpgradeLevel = 1;
    public int damageUpgradeLevel = 1;
    public int radiusUpgradeLevel = 1;

    public float intervalMultiplier = 0.9f;
    public float damageMultiplier = 1.2f;
    public float radiusMultiplier = 1.1f;

    private void Start()
    {
        UpdateAuraStats();
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad > nextActionTime)
        {
            nextActionTime += baseAttackInterval;
            UseSkill();
        }
    }

    public void UseSkill()
    {
        _auraEffect.Play();
        _trigger.DOScale(Vector3.one * baseRadius, .5f).OnComplete(() => _trigger.transform.localScale = Vector3.zero);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            other.GetComponent<Enemy>().Damage(baseDamageAmount);
        }
    }

    public void UpgradeAuraSkill(UpgradeType upgradeType)
    {
        switch (upgradeType)
        {
            case UpgradeType.AuraRate:
                attackIntervalUpgradeLevel++;
                break;
            case UpgradeType.AuraDamage:
                damageUpgradeLevel++;
                break;
            case UpgradeType.AuraAttackRange:
                radiusUpgradeLevel++;
                break;
        }
        UpdateAuraStats();
    }

    private void UpdateAuraStats()
    {
        attackIntervalUpgradeLevel = UpgradeManager.Instance.GetUpgradeLevel(UpgradeType.AuraRate);
        damageUpgradeLevel = UpgradeManager.Instance.GetUpgradeLevel(UpgradeType.AuraDamage);
        radiusMultiplier = UpgradeManager.Instance.GetUpgradeLevel(UpgradeType.AuraAttackRange);
        baseAttackInterval = baseAttackInterval * Mathf.Pow(intervalMultiplier, attackIntervalUpgradeLevel - 1);
        baseDamageAmount = baseDamageAmount * Mathf.Pow(damageMultiplier, damageUpgradeLevel - 1);
        baseRadius = baseRadius * Mathf.Pow(radiusMultiplier, radiusUpgradeLevel - 1);
    }
}
