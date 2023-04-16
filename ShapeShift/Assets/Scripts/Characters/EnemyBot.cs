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
    private void Start()
    {
        TMP.text = "Level: " + characterLevel.ToString();   
    }
    public override void Dead()
    {
        m_Pickable.SpawnPickable(1, transform);
        base.Dead();
    }
}
