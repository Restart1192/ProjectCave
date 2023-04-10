using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState
{
    public abstract void EnterState(EnemyStateManager enemy);

    public abstract void updateState(EnemyStateManager enemy);

    public abstract string getInfoState(EnemyStateManager enemy);
}
