using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostarNormalAttackState : HeroState
{
    protected Mostar hero;

    public MostarNormalAttackState(Hero _heroBase, HeroStateMachine _stateMachine, string _animBoolName, Mostar _hero) : base(_heroBase, _stateMachine, _animBoolName)
    {
        this.hero = _hero;
    }

    public override void Enter()
    {
        base.Enter();
        
        hero.currentStateIndex++;
    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void Update()
    {
        base.Update();

        hero.SetZeroVelocity();

        if (triggerCalled)
        {
            hero.MostarMovement();
        }
    }
}
