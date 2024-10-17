using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostarSpellCastState : HeroState
{
    protected Mostar hero;

    private int amountOfSpells;
    private float spellTimer;

    public MostarSpellCastState(Hero _heroBase, HeroStateMachine _stateMachine, string _animBoolName, Mostar _hero) : base(_heroBase, _stateMachine, _animBoolName)
    {
        this.hero = _hero;
    }

    public override void Enter()
    {
        base.Enter();

        hero.FindAllEnemiesInArea(hero.transform.position);
        amountOfSpells = hero.amountOfSpells;
        spellTimer = .5f;

        hero.currentStateIndex++;
    }

    public override void Exit()
    {
        base.Exit();

        hero.inTeleportTime = true; // Because after this state is teleport state (sneaky skill)
    }

    public override void Update()
    {
        base.Update();

        spellTimer -= Time.deltaTime;

        if (CanCast())
        {
            hero.RandomPosition();
            hero.CastSpell(hero.enemyPosition);
        }

        if (amountOfSpells <= 0)
            stateMachine.ChangeState(hero.heroStates[hero.currentStateIndex]);


    }

    private bool CanCast()
    {
        if (amountOfSpells > 0 && spellTimer < 0)
        {
            amountOfSpells--;
            spellTimer = hero.spellCooldown;
            return true;
        }

        return false;
    }
}
