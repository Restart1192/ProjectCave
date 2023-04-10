using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtackState : EnemyBaseState
{
    //Inicializar estado
    public override void EnterState(EnemyStateManager enemy)
    {
        enemy.ChangeConditionMove(false, false, true);
    }

    //Update estado
    public override void updateState(EnemyStateManager enemy)
    {
        if (enemy.CheckMove())
        {
            enemy.SwitchState(enemy.walkState);
        }
        else if(!enemy.CheckMove())
        {
            enemy.SwitchState(enemy.idleState);
        }
    }

    //Informa��o do estado
    public override string getInfoState(EnemyStateManager enemy)
    {
        return "Atack";
    }
}
