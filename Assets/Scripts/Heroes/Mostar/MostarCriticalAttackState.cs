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

/*        if(hero.inTeleportTime == false)
            hero.countOfAttack = 0;*/

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
            /*if(hero.inTeleportTime == true)
            {
                stateMachine.ChangeState(hero.teleportState);
            } else
            {
                stateMachine.ChangeState(hero.battleState);
            }*/

            stateMachine.ChangeState(hero.heroStates[hero.currentStateIndex]);
        }
    }
}
