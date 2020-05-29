using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSword : Weapon
{
    [SerializeField]private Animator anim;
    [SerializeField]private Transform attackPoint;
    [SerializeField]private float attackRange;
    [SerializeField]private LayerMask enemyLayers;
    protected override void DoAttack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        { 
            anim.SetTrigger("Attack");
            //???
            Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, attackRange,enemyLayers);
            foreach (Collider2D col in hitEnemys)
            {
                col.GetComponent<Enemy>().TakeDamage(5.0f);
            }
        }
    }
}
