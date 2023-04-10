using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    //Inicializar estado
    public override void EnterState(PlayerStateManager player)
    {
        player.ChangeConditionMove(false, true, false);
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

        if (player.CheckJump())
        {
            player.SwitchState(player.jumpState);
        }
    }

    //Informação do estado
    public override string getInfoState(PlayerStateManager player)
    {
        return "Run";
    }
}
