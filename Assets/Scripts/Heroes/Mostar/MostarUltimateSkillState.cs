using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostarUltimateSkillState : HeroState
{
    protected Mostar hero;
    private int amountOfSpells;
    private float spellTimer;

    public MostarUltimateSkillState(Hero _heroBase, HeroStateMachine _stateMachine, string _animBoolName, Mostar _hero) : base(_heroBase, _stateMachine, _animBoolName)
    {
        this.hero = _hero;
    }

    public override void Enter()
    {
        base.Enter();

        hero.FindAllEnemiesInArea(hero.transform.position);
        //amountOfSpells = hero.amountOfSpells;

        hero.CallUltimateSkillWithDelay();

    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void Update()
    {
        base.Update();

        stateMachine.ChangeState(hero.idleState);

    }

}
