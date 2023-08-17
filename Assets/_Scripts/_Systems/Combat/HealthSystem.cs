using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour, IDamageable
{
    public Animator anim;
    public float maxHp;
    public int damage;
    public float currentHP;

    public UnityEvent onDeath;
    private bool _hasSpawned;
    private void Start()
    {
        currentHP = maxHp;
    }
    public void TakeDamage(int damage)
    {
        currentHP = Mathf.Clamp(currentHP - damage, 0, maxHp);

        if (currentHP <= 0)
        {
            anim.SetTrigger(AnimationString.s_die);
            onDeath.Invoke();
            Destroy(gameObject, 1f);
        }
        else
        {
            anim.SetTrigger(AnimationString.s_hurt);
        }
    }
    
    public void ItemSpawn(GameObject item)
    {
        if (!_hasSpawned)
        {
            _hasSpawned = true;
            GameManeger.Instance.enemyCount++;
            GameObject holder = GameObject.Find("ItemHolder");
            GameObject xItem = Instantiate(item, transform.position + new Vector3(0, 3f,0), Quaternion.identity, holder.transform);
            xItem.GetComponent<Rigidbody2D>().AddForce(Vector2.up *10, ForceMode2D.Impulse);
        }
    }
}
