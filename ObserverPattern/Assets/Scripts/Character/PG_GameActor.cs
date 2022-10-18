using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PG_GameActor : MonoBehaviour
{
    
    public float MoveSpeed;
    public float turnSmoothVelocity;
    protected Animator anim;
    protected Rigidbody rigidBody = null;
    protected BoxCollider collider = null;
    protected PG_Main main;

    public void InitActor()
    {
        rigidBody = GetComponent<Rigidbody>();
        collider = GetComponent<BoxCollider>();
        anim = GetComponent<Animator>();
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
    public virtual void Move()
    {

    }
    public abstract void Update_Actor();
    public abstract void Start_Actor();
}
