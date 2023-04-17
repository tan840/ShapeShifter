using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyBoss : Enemy
{

    public TMP_Text TMP;

    public override void Start()
    {
        base.Start();
        TMP.text = "Level: " + characterLevel.ToString();
    }
    public override void Dead()
    {
        m_Pickable.SpawnPickable(2, transform);
        base.Dead();
    }
}
