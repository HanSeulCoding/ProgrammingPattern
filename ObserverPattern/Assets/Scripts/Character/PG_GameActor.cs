using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PG_GameActor : MonoBehaviour
{
    
    public float speed;
    public float turnSmoothVelocity;
    protected Animator animator;
    protected Rigidbody rigidBody = null;
    protected BoxCollider collider = null;
    protected PG_Main main;

    public void InitActor()
    {
        rigidBody = GetComponent<Rigidbody>();
        collider = GetComponent<BoxCollider>();
        animator = GetComponent<Animator>();
        main = PG_Main.Instance;
    }
    public virtual void Skill()
    {

    }
    public virtual void EndSkill()
    {

    }
    public virtual void Attack()
    {
    }
    public virtual void EndAttack()
    {
    }
    public virtual void Move(Vector2 axisRaw, KeyType keyType)
    {

    }
    public abstract void Update_Actor();
    public abstract void Start_Actor();
}
