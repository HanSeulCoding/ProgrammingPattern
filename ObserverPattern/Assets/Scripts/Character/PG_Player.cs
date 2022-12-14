using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PG_Player : PG_GameActor
{
    [SerializeField]
    Transform cameraArm;
    Vector3 dir;
    float turnSmoothTime = 0.1f;
    protected bool[] isPressMoveCommand = new bool[4];
    // Start is called before the first frame update
    public override void Start_Actor()
    {
        InitActor();
        PG_Global._animEndDelegate[(int)AnimEndState.ATTACK] += EndAttack;
        PG_Global._animEndDelegate[(int)AnimEndState.SKILL] += EndSkill;
        cameraArm = PG_Main.Instance.ActorCamera.transform;
    }
    // Update is called once per frame
    public override void Update_Actor()
    {
        PlayerControl();
        Move_End();
    }
    public override void Attack()
    {
        anim.SetBool("isAttack", true);
        StartCoroutine(PG_ActorUtility.CheckAnimationState(anim, "Ekard_Attack_01_h", LayerType.UPPER, AnimEndState.ATTACK));
    }
    public override void EndAttack()
    {
        anim.SetBool("isAttack", false);
    }
    public override void Skill()
    {

    }
    public override void EndSkill()
    {

    }
    public override void Move(Vector2 axisRaw, KeyType keyType)
    {
        isPressMoveCommand[(int)keyType] = true;

        float inputX = axisRaw.x;
        float inputY = axisRaw.y;

        dir = new Vector3(inputX, 0.0f, inputY);
        bool isMoveEnd = false;
        if (dir.magnitude > 0.1f)
        {
            isMoveEnd = true;
            anim.SetBool("isMove", true);

            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0, cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0, cameraArm.right.z).normalized;
            dir = lookRight * dir.x + lookForward * dir.z;
            dir = dir.normalized;

            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
            transform.position += dir * MoveSpeed * Time.deltaTime;
        }
    }
    private void PlayerControl()
    {
        InputHandler inputHandler = PG_Main.Instance.InputHandler;

        inputHandler.handleInput(this, CommandsType.UP, KeyPressType.PRESS);
        inputHandler.handleInput(this, CommandsType.DOWN, KeyPressType.PRESS);
        inputHandler.handleInput(this, CommandsType.RIGHT, KeyPressType.PRESS);
        inputHandler.handleInput(this, CommandsType.LEFT, KeyPressType.PRESS);
        inputHandler.handleInput(this, CommandsType.ENTER, KeyPressType.PRESS);
        inputHandler.handleInput(this, CommandsType.SPACE, KeyPressType.PRESS);

        inputHandler.handleInput(this, CommandsType.UP, KeyPressType.DOWN);
        inputHandler.handleInput(this, CommandsType.DOWN, KeyPressType.DOWN);
        inputHandler.handleInput(this, CommandsType.RIGHT, KeyPressType.DOWN);
        inputHandler.handleInput(this, CommandsType.LEFT, KeyPressType.DOWN);
        inputHandler.handleInput(this, CommandsType.ENTER, KeyPressType.DOWN);
        inputHandler.handleInput(this, CommandsType.SPACE, KeyPressType.DOWN);

        inputHandler.handleInput(this, CommandsType.UP, KeyPressType.UP);
        inputHandler.handleInput(this, CommandsType.DOWN, KeyPressType.UP);
        inputHandler.handleInput(this, CommandsType.RIGHT, KeyPressType.UP);
        inputHandler.handleInput(this, CommandsType.LEFT, KeyPressType.UP);
        inputHandler.handleInput(this, CommandsType.SPACE, KeyPressType.UP);
        inputHandler.handleInput(this, CommandsType.ENTER, KeyPressType.UP);
    }
    private void Move_End()
    {
        if (!isPressMoveCommand[0] && !isPressMoveCommand[1] && !isPressMoveCommand[2] && !isPressMoveCommand[3])
        {
            anim.SetBool("isMove", false);
        }
    }
    public void Input_IsPressMoveCommand(KeyType keyType)
    {
        isPressMoveCommand[(int)keyType] = false;
    }
}
