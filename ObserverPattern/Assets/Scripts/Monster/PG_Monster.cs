using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PG_Monster : PG_GameActor
{
    [SerializeField]
    private List<GameObject> targetBox;
    private NavMeshAgent navMeshAgent;
    private ActorState state;
    private bool isAttack;

    public override void Start_Actor()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public override void Update_Actor()
    {
        for(int i = 0; i < targetBox.Count; ++i)
        {

        }
    }
    protected virtual IEnumerator FSM()
    {
        yield return null;

        while (true)
        {
            yield return StartCoroutine(state.ToString());
        }
    }
    protected virtual IEnumerator Idle()
    {
        yield return null;
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            anim.SetTrigger("Idle");
        }

        if (CanAttackState())
        {
            if (isAttack)
            {
                state = ActorState.Attack;
            }
            else
            {
                state = ActorState.Idle;
                transform.LookAt(main.player.transform.position);
            }
        }
        else
        {
            state = ActorState.Move;
        }
    } //Move 2���� ��� 
    //���� ���� �� Player�� ���󰡴� Move(Player�� �־��� �� �ִ�.)
    //���� ������

    protected virtual IEnumerator Move()
    {
        yield return null;
        int targetCount = 0;
        navMeshAgent.destination = targetBox[0].transform.position;
        if(navMeshAgent.isOnOffMeshLink)
        {

        }

        //navMeshAgent.destination = targetBox
        //navMeshAgent.is
    }

    private bool CanAttackState() //���� ���� ���� �Ǵ�
    {
        return false;
    }
}
