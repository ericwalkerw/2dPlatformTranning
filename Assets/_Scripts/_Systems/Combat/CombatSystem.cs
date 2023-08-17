using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    public HealthSystem health;
    private void Start()
    {
        health = GetComponentInParent<HealthSystem>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {

    }

    public virtual void DamageObject(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponentInParent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(health.damage);
        }
    }
}
