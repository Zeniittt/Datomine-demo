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

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        /* if (Input.GetKeyDown(KeyCode.B))
         {
             hero.inTeleportTime = true;
             stateMachine.ChangeState(hero.teleportState);
         }

         if (Input.GetKeyDown(KeyCode.Q))
         {
             if(hero.CanCastSpell())
                 stateMachine.ChangeState(hero.spellCastState);
         }

         if (hero.IsEnemyDetected())
         {
             stateTimer = hero.battleTime;
             if(CanAttack())
             {
                 if(CanCritical())
                     stateMachine.ChangeState(hero.criticalAttackState);
                 else
                     stateMachine.ChangeState(hero.normalAttackState);
             }

         }
         else
         {
             stateMachine.ChangeState(hero.idleState);
         }

         //hero.SetVelocity(hero.moveSpeed * hero.facingDirection, rigidbody.velocity.y);  */

        stateMachine.ChangeState(hero.heroStates[hero.currentStateIndex]);

    }

    private bool CanAttack()
    {
        if(Time.time >= hero.attackCooldown + hero.recentAttacked)
        {
            hero.recentAttacked = Time.time;
            return true;
        }

        return false;
    }

    private bool CanCritical()
    {
        if(hero.countOfAttack == hero.criticalAttack)
            return true;

        return false;
    }


}
