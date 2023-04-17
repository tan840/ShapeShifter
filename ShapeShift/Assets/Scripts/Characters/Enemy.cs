using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Base Class for all enemies
/// </summary>
public class Enemy : Character
{
    [SerializeField] protected PickableItemManager m_Pickable;

    public virtual void Dead()
    {
        m_Anim.SetTrigger("Dead");
        Destroy(gameObject, 2f);
    }
    public virtual void Attack()
    {
        m_Anim.SetTrigger("Attack");
        //Destroy(gameObject, 2f);
    }
}
