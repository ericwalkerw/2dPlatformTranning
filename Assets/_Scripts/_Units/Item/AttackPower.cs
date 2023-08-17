using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPower : ItemLoot
{
    public override void OnActive(Collider2D collision, ICollectBuff buff)
    {
        base.OnActive(collision, buff);
        buff.AttackBuff();
    }
}
