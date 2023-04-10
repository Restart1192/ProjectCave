using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    //Estado atual do player
    EnemyBaseState currentState;

    //Estado parado,andar e run
    [SerializeField] public EnemyIdleState idleState = new EnemyIdleState();
    [SerializeField] public EnemyWalkState walkState = new EnemyWalkState();
    [SerializeField] public EnemyAtackState atackState = new EnemyAtackState();

    //Animação do player
    [SerializeField] public Animator animator;

    private bool isMove = false;
    private bool isRun = false;
    private bool isAtack = false;

    private Vector3 oldPosition;
    private Vector3 newPosition;

    void Start()
    {
        currentState = idleState;
        currentState.EnterState(this);

        //CheckPos
        oldPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.updateState(this);
        CheckState();
    }

    //Alterar o estado
    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    //Obter informação do estado
    public string GetInfoState()
    {
        return currentState.getInfoState(this);
    }

    //Alterar condições de animação
    public void ChangeConditionMove(bool isWalking, bool isRunning, bool isAtack)
    {
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isAtack", isAtack);
    }

    public bool CheckMove()
    {
        return isMove;
    }

    public bool CheckRun()
    {
        return isRun;
    }

    public bool CheckAtack()
    {
        return isAtack;
    }

    public void CheckState()
    {
        newPosition = transform.position;

        if (oldPosition != newPosition)
        {
            isMove = true;
        }
        else
        {
            isMove = false;
        }

        oldPosition = transform.position;

    }

    public void atackMov()
    {
        isMove = false;
        isRun = false;
        isAtack = true;
    }

    public void atackStop()
    {
        isMove = false;
        isRun = false;
        isAtack = false;
    }
}
