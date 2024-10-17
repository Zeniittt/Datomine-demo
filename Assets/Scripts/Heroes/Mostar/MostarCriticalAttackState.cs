using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostarCriticalAttackState : HeroState
{
    Mostar hero;

    public MostarCriticalAttackState(Hero _heroBase, HeroStateMachine _stateMachine, string _animBoolName, Mostar _hero) : base(_heroBase, _stateMachine, _animBoolName)
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
        if (hero.inTeleportTime)
            hero.inTeleportTime = false;
    }

    public override void Update()
    {
        base.Update();

        hero.SetZeroVelocity();

        if (triggerCalled)
        {

            if(hero.IsEnemyDetected())
            {
                stateMachine.ChangeState(hero.heroStates[hero.currentStateIndex]);
            }
            else
            {
                if (hero.heroStates[hero.currentStateIndex-2] == hero.teleportState)
                    stateMachine.ChangeState(hero.heroStates[hero.currentStateIndex]);
                else
                    stateMachine.ChangeState(hero.moveState);
            }
        }
    }
}
