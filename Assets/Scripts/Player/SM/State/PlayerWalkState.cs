using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    //Inicializar estado
    public override void EnterState(PlayerStateManager player)
    {
        player.ChangeConditionMove(true, false, false);
    }

    //Update estado
    public override void updateState(PlayerStateManager player)
    {
        if (!(player.CheckMove()))
        {
            player.SwitchState(player.idleState);
        }

        if (player.CheckMove() && player.CheckRun())
        {
            player.SwitchState(player.runState);
        }

        if (player.CheckJump())
        {
            player.SwitchState(player.jumpState);
        }
    }

    //Informação do estado
    public override string getInfoState(PlayerStateManager player)
    {
        return "Walk";
    }
}
