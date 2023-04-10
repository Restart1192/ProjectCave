using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkState : EnemyBaseState
{
    //Inicializar estado
    public override void EnterState(EnemyStateManager enemy)
    {
        enemy.ChangeConditionMove(true, false, false);
    }

    //Update estado
    public override void updateState(EnemyStateManager enemy)
    {
        if (!(enemy.CheckMove()) && !(enemy.CheckAtack()))
        {
            enemy.SwitchState(enemy.idleState);
        }
        else if (enemy.CheckAtack())
        {
            enemy.SwitchState(enemy.atackState);
        }
    }

    //Informação do estado
    public override string getInfoState(EnemyStateManager enemy)
    {
        return "Walk";
    }
}
