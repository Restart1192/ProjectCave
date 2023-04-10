using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState
{
    public abstract void EnterState(PlayerStateManager player);

    public abstract void updateState(PlayerStateManager player);

    public abstract string getInfoState(PlayerStateManager player);

}
