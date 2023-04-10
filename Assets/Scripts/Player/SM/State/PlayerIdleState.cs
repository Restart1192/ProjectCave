using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    //Inicializar estado
    public override void EnterState(PlayerStateManager player)
    {
        player.ChangeConditionMove(false, false, false);
    }

    //Update estado
    public override void updateState(PlayerStateManager player)
    {
        if (player.CheckJump())
        {
            player.SwitchState(player.jumpState);
        }

        if (player.CheckMove() && !player.CheckRun())
        {
            player.SwitchState(player.walkState);
        }

        if (player.CheckMove() && player.CheckRun())
        {
            player.SwitchState(player.runState);
        }
    }

    //Informação do estado
    public override string getInfoState(PlayerStateManager player)
    {
        return "Idle";
    }
}
