using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/// <summary>
/// enemey bot
/// </summary>
public class EnemyBot : Enemy
{
    public TMP_Text TMP;

    public override void Start()
    {
        base.Start();
        TMP.text = "Level: " + characterLevel.ToString();
    }

    //Enemy death function
    public override void Dead()
    {
        m_Pickable.SpawnPickable(1, transform);
        base.Dead();
    }

    //Enemy attack function
    public override void Attack()
    {
        base.Attack();
    }
}
