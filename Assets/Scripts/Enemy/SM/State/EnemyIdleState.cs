using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    //Inicializar estado
    public override void EnterState(EnemyStateManager enemy)
    {
        enemy.ChangeConditionMove(false, false, false);
    }

    //Update estado
    public override void updateState(EnemyStateManager enemy)
    {
        if (enemy.CheckMove() && !(enemy.CheckAtack()))
        {
            enemy.SwitchState(enemy.walkState);
        }
        else if (enemy.CheckAtack())
        {
            enemy.SwitchState(enemy.atackState);
        }
    }

    //Informação do estado
    public override string getInfoState(EnemyStateManager enemy)
    {
        return "Idle";
    }
}
