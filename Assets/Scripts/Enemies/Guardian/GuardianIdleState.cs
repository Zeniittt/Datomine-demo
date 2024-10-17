using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianIdleState : EnemyState
{
    protected Guardian enemy;
    public GuardianIdleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Guardian _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
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

        enemy.SetZeroVelocity();

        if (stateTimer < 0)
            stateMachine.ChangeState(enemy.moveState);
    }
}
