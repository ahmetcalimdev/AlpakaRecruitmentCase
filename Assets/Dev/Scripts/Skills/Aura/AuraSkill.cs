using DG.Tweening;
using UnityEngine;

public class AuraSkill : MonoBehaviour
{
    [SerializeField]
    private Transform _trigger;
    [SerializeField]
    private ParticleSystem _auraEffect;
    private float nextActionTime = 0.0f;
    public float period = 1f;
    public float damageAmount;

    void Update()
    {
        if (Time.timeSinceLevelLoad > nextActionTime)
        {
            nextActionTime += period;
            UseSkill();
        }
    }
    public void UseSkill() 
    {
        _auraEffect.Play();
        _trigger.DOScale(Vector3.one * 4f, .5f).OnComplete(()=> _trigger.transform.localScale = Vector3.zero);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            Debug.Log("Damage from aura");
            other.GetComponent<Enemy>().Damage(damageAmount);
        }
        
    }
}
