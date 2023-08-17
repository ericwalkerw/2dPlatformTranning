using UnityEngine;

public class PlayerCombat : CombatSystem
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            DamageObject(collision);
        }
    }
    public override void DamageObject(Collider2D collision)
    {
        base.DamageObject(collision);
    }
}
