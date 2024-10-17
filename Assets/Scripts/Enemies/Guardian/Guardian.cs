using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian : Enemy
{
    #region

    public GuardianIdleState idleState { get; private set; }
    public GuardianMoveState moveState { get; private set; }

    #endregion

    protected override void Awake()
    {
        base.Awake();

        idleState = new GuardianIdleState(this, stateMachine, "Idle", this);
        moveState = new GuardianMoveState(this, stateMachine, "Move", this);
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
