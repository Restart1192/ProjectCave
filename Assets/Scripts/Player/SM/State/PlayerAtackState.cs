using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtackState : PlayerBaseState
{
    //Inicializar estado
    public override void EnterState(PlayerStateManager player)
    {
        player.ChangeConditionMove(false, false, false);
    }

    //Update estado
    public override void updateState(PlayerStateManager player)
    {
        if (!(player.CheckRun()))
        {
            player.SwitchState(player.idleState);
        }

        if (player.CheckMove() && !player.CheckRun())
        {
            player.SwitchState(player.walkState);
        }
    }

    //Informação do estado
    public override string getInfoState(PlayerStateManager player)
    {
        return "Run";
    }
}
