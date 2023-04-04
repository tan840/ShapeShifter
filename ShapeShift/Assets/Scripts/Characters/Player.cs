using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Player Class
/// </summary>
public class Player : Character
{
    public override void Start()
    {
        base.Start();
    }
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy.IsDead) return;
            if (enemy.CharacterLevel <= CharacterLevel)
            {
                print("Enemy Killed");
                CharacterLevel += enemy.CharacterLevel;
                enemy.IsDead = true;
                enemy.Dead(); 
            }
            else
            {
                print("PlayerDead");
            }
        }
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Rb.velocity = m_MoveSpeed * new Vector3(horizontal, 0, vertical);
        //  m_Rb.AddForce(m_MoveSpeed * Time.deltaTime * new Vector3(horizontal,0,vertical),ForceMode.Impulse);
    }
}
