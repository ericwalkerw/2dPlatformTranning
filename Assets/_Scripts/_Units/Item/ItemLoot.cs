using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLoot : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            ICollectBuff buff = collision.collider.GetComponent<ICollectBuff>();
            OnActive(collision.collider, buff);
        }
    }

    public virtual void OnActive(Collider2D collision, ICollectBuff buff)
    {
        Destroy(gameObject);
    }
}
