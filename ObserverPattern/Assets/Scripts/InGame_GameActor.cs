using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void AnimEndDelegate();
public class InGame_GameActor : MonoBehaviour
{
    
    public float speed;
    public float turnSmoothVelocity;
    Rigidbody rigidBody = null;
    BoxCollider collider = null;
    Animator animator;


    private bool[] isPressMoveCommand = new bool[4];
    private Transform cam;
    private PG_Main main;


    Vector3 dir;
    float turnSmoothTime = 0.1f;
    AnimEndDelegate[] _animEndDelegate = new AnimEndDelegate[(int)AnimEndState.COUNT];

    public void InitActor()
    {
        rigidBody = GetComponent<Rigidbody>();
        collider = GetComponent<BoxCollider>();
        animator = GetComponent<Animator>();
        _animEndDelegate[(int)AnimEndState.ATTACK] += EndAttack;
        _animEndDelegate[(int)AnimEndState.SKILL] += EndSkill;
        main = PG_Main.Instance;
        cam = main.ActorCamera.transform;
    }
    public void Skill()
    {

    }
    public void EndSkill()
    {

    }
    public void Attack()
    {
        animator.SetBool("isAttack", true);
        StartCoroutine(CheckAnimationState("Ekard_Attack_01_h", LayerType.UPPER, AnimEndState.ATTACK));
    }
    public void EndAttack()
    {
        animator.SetBool("isAttack", false);
    }
    public void Move(Vector2 axisRaw, CommandsType commandsType)
    {
        isPressMoveCommand[(int)commandsType] = true;

        float inputX = axisRaw.x;
        float inputY = axisRaw.y;

        dir = new Vector3(inputX, 0.0f, inputY);
        bool isMoveEnd = false;
        if(dir.magnitude > 0.1f)
        {
            isMoveEnd = true;
            animator.SetBool("isMove", true);

            dir = dir.normalized;
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
            transform.position += dir * speed * Time.deltaTime;
        }
    }

    public void Input_IsPressMoveCommand(CommandsType commandsType)
    {
        isPressMoveCommand[(int)commandsType] = false;
    }
    public void Move_End()
    {
        if (!isPressMoveCommand[0] && !isPressMoveCommand[1] && !isPressMoveCommand[2] && !isPressMoveCommand[3])
        {
            animator.SetBool("isMove", false);
        }
    }
    IEnumerator CheckAnimationState(string animName, LayerType layerType, AnimEndState state)
    {
        while (!animator.GetCurrentAnimatorStateInfo((int)layerType).IsName(animName))
        {
            yield return null;
        }
        while (animator.GetCurrentAnimatorStateInfo((int)layerType).normalizedTime < 0.8f)
        {
            yield return null;
        }

        _animEndDelegate[(int)state]();
    }

}
