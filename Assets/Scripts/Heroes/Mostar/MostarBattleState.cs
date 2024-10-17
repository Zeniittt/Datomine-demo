using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostarBattleState : HeroState
{
    protected Mostar hero;

    public MostarBattleState(Hero _heroBase, HeroStateMachine _stateMachine, string _animBoolName, Mostar _hero) : base(_heroBase, _stateMachine, _animBoolName)
    {
        this.hero = _hero;
    }

    public override void Enter()
    {
        base.Enter();

        hero.isInitialTime = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        stateMachine.ChangeState(hero.heroStates[hero.currentStateIndex]);
    }

}
