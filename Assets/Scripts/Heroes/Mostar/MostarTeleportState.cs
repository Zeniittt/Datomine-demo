using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostarTeleportState : HeroState
{
    protected Mostar hero;

    public MostarTeleportState(Hero _heroBase, HeroStateMachine _stateMachine, string _animBoolName, Mostar _hero) : base(_heroBase, _stateMachine, _animBoolName)
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

        if (hero.currentStateIndex == hero.heroStates.Count)
            hero.currentStateIndex = 0;
    }

    public override void Update()
    {
        base.Update();

        if(triggerCalled)
        {
            /*    if (hero.inTeleportTime)
                    stateMachine.ChangeState(hero.criticalAttackState);
                else
                    stateMachine.ChangeState(hero.battleState);
                //hero.inTeleportTime = false;*/

                stateMachine.ChangeState(hero.heroStates[hero.currentStateIndex]);

        }
    }
}
