using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderMoveState : EnemyState
{
    protected Solider enemy;
    public SoliderMoveState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Solider _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        enemy.SetVelocity(-enemy.moveSpeed, rigidbody.velocity.y);

        if (enemy.IsEnemyDetected())
            stateMachine.ChangeState(enemy.idleState);
    }
}
