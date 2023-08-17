using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpPotion : ItemLoot
{
    public override void OnActive(Collider2D collision, ICollectBuff buff)
    {
        base.OnActive(collision, buff);
        buff.HPBuff();
    }
}
