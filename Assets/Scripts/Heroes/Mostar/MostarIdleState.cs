using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostarIdleState : MostarGroundedState
{
    public MostarIdleState(Hero _heroBase, HeroStateMachine _stateMachine, string _animBoolName, Mostar _hero) : base(_heroBase, _stateMachine, _animBoolName, _hero)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = hero.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
            stateMachine.ChangeState(hero.moveState);
    }
}
