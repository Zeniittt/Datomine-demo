using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostarMoveState : MostarGroundedState
{
    public MostarMoveState(Hero _heroBase, HeroStateMachine _stateMachine, string _animBoolName, Mostar _hero) : base(_heroBase, _stateMachine, _animBoolName, _hero)
    {
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

        hero.SetVelocity(hero.moveSpeed, rigidbody.velocity.y);

        if (hero.IsEnemyDetected())
            stateMachine.ChangeState(hero.battleState);
    }
}
