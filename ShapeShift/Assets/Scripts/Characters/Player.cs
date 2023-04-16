using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

/// <summary>
/// Player Class
/// </summary>
public class Player : Character
{
    [SerializeField] float m_RotationSpeed = 10;
    [SerializeField] bool m_CanMove;


    [SerializeField] AudioSource Slash;

    [SerializeField] TMP_Text text;
    public bool CanMove { get => m_CanMove; set => m_CanMove = value; }

    public override void Start()
    {
        text.text = "Level: " + characterLevel.ToString();
        base.Start();
        m_CanMove = true;
    }
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.gameObject.CompareTag("Enemy"))
        {
            print("Triggered");
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            print(enemy);
            if (enemy.IsDead) return;
            if (enemy.CharacterLevel <= CharacterLevel)
            {
                //print("Enemy Killed");
                Slash.Play();
                CharacterLevel += enemy.CharacterLevel;
                text.text = "Level: " + characterLevel.ToString();
                StartCoroutine(KillSequence());
                IEnumerator KillSequence()
                {
                    m_Anim.SetTrigger("Attack");
                    yield return null;
                    enemy.IsDead = true;
                    enemy.Dead();
                    m_Anim.ResetTrigger("Attack");
                }
                
            }
            else
            {
                //print("PlayerDead");
            }
        }
    }

    private void Update()
    {
        if (!m_CanMove)
        {
            m_Anim.SetBool("IsRunning", false);
            return;
        }
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 tempVect = new Vector3(horizontal, 0, vertical);
        tempVect = tempVect.normalized * m_MoveSpeed * Time.deltaTime;
        m_Rb.MovePosition(transform.position + tempVect);

        if (tempVect != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(tempVect, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, m_RotationSpeed * Time.deltaTime);
        }
        if (tempVect.normalized.magnitude > 0.2f)
        {
            m_Anim.SetBool("IsRunning", true);
        }
        else
        {
            m_Anim.SetBool("IsRunning", false);
        }
    }
}
