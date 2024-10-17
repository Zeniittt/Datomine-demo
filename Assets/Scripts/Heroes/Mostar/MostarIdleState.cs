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


        if (hero.isInitialTime)
        {
            stateTimer = hero.idleTimeInitial;

        } else
        {
            stateTimer = hero.idleTime;
            hero.currentStateIndex++;

        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        hero.SetZeroVelocity();
        
        if (stateTimer < 0)
        {
            if (hero.isInitialTime)
                stateMachine.ChangeState(hero.moveState);
            else
            {
                hero.MostarMovement();
            }
        }
            

    }
}
