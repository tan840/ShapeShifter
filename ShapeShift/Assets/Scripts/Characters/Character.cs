using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Base Class for all characters
/// </summary>
public abstract class Character : MonoBehaviour
{
    [SerializeField] protected int characterLevel = 1;
    [SerializeField] protected float m_MoveSpeed = 10;
    [SerializeField] protected Rigidbody m_Rb;
    [SerializeField] protected Animator m_Anim;
    [SerializeField] protected bool isDead;

    public int CharacterLevel { get => characterLevel; set => characterLevel = value; }
    public bool IsDead { get => isDead; set => isDead = value; }

    public virtual void Start()
    {
        
    }
    public virtual void OnTriggerEnter(Collider other)
    {
        //print("Hit");
    }
}
