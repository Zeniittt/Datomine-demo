using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderIdleState : EnemyState
{
    protected Solider enemy;
    public SoliderIdleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Solider _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = enemy.idleTimeInitial;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
            stateMachine.ChangeState(enemy.moveState);
    }
}
