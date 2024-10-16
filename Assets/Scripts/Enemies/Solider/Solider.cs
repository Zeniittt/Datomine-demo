using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solider : Enemy
{
    #region

    public SoliderIdleState idleState { get; private set; }
    public SoliderMoveState moveState { get; private set; }

    #endregion

    protected override void Awake()
    {
        base.Awake();

        idleState = new SoliderIdleState(this, stateMachine, "Idle", this);
        moveState = new SoliderMoveState(this, stateMachine, "Move", this);
    }

    protected override void Start()
    {
        base.Start();

        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }
}
