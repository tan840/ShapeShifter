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
        m_Pickable.SpawnPickable(1, transform);
        Destroy(gameObject);
    }
}
