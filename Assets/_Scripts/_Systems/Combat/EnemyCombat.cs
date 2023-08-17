using UnityEngine;

public class EnemyCombat : CombatSystem
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DamageObject(collision);
        }
    }
    public override void DamageObject(Collider2D collision)
    {
        base.DamageObject(collision);
    }
}
