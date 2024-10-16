using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Mostar : Hero
{
    #region

    public MostarIdleState idleState { get; private set; }
    public MostarMoveState moveState { get; private set; }
    public MostarBattleState battleState { get; private set; }
    public MostarNormalAttackState normalAttackState { get; private set; }
    public MostarCriticalAttackState criticalAttackState { get; private set; }
    public MostarTeleportState teleportState { get; private set; }
    public MostarSpellCastState spellCastState { get; private set; }

    #endregion

    [Header("Critical Informations")]
    public int countOfAttack;
    public int criticalAttack;

    [Header("Teleport Informations")]
    public Vector2 boxSize;
    public List<Enemy> enemies;
    [SerializeField] private float xOffset;
    public bool inTeleportTime;
    public Vector3 positionTeleport;
    public Vector3 initalPosition;

    [Header("Spell Informations")]
    [SerializeField] private GameObject spellPrefab;
    public int amountOfSpells;
    public float spellCooldown;
    private float lastTimeCast;
    [SerializeField] private int yOffset;
    [SerializeField] private float spellStateCooldown;

    [Header("States Order")]
    public List<HeroState> heroStates;
    public int currentStateIndex = 0;

    protected override void Awake()
    {
        base.Awake();

        idleState = new MostarIdleState(this, stateMachine, "Idle", this);
        moveState = new MostarMoveState(this, stateMachine, "Move", this);
        battleState = new MostarBattleState(this, stateMachine, "Idle", this);
        normalAttackState = new MostarNormalAttackState(this, stateMachine, "Attack", this);
        criticalAttackState = new MostarCriticalAttackState(this, stateMachine, "Critical", this);
        teleportState = new MostarTeleportState(this, stateMachine, "Teleport", this);
        spellCastState = new MostarSpellCastState(this, stateMachine, "SpellCast", this);
    }

    protected override void Start()
    {
        base.Start();

        heroStates = new List<HeroState>
        {
            normalAttackState,
            normalAttackState,
            criticalAttackState,
            spellCastState,
            teleportState,
            criticalAttackState,
            teleportState,
        };

        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }

    public void FindAllEnemiesInArea(Vector2 _position)
    {
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(_position, boxSize, 0f, whatIsEnemy);

        foreach (Collider2D collider in hitColliders)
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemies.Add(enemy);
                Debug.Log(enemy.transform.position);
            }
        }
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, boxSize);
    }

    public void RandomPosition()
    {
        int enemyRandom = Random.Range(0, enemies.Count);
        Transform enemy = enemies[enemyRandom].transform;

        int facingDirectionEnemy = enemy.GetComponent<Enemy>().facingDirection;

        positionTeleport = new Vector3(enemy.position.x, enemy.position.y, facingDirectionEnemy);
    }

    public void TeleportToPosition()
    {
        if (inTeleportTime == true)
        {
            FindAllEnemiesInArea(transform.position);
            RandomPosition();


            if (positionTeleport.z == -1)
            {
                initalPosition = transform.position;
                Flip();

                transform.position = new Vector3(positionTeleport.x + xOffset, positionTeleport.y);
            }
            else
            {
                initalPosition = transform.position;
                transform.position = new Vector3(positionTeleport.x - xOffset, positionTeleport.y);
            }
        } else
        {
            Debug.Log("toiday");

            transform.position = initalPosition;
            Flip();
        }


        enemies.Clear();
    }

    public void CastSpell(Vector2 _positionEnemy)
    {
        Vector3 spellPosition = new Vector3(_positionEnemy.x, yOffset);

        GameObject newSpell = Instantiate(spellPrefab, spellPosition, Quaternion.identity);
    }

    public bool CanCastSpell()
    {
        if (Time.time >= lastTimeCast + spellStateCooldown)
        {
            return true;
        }
        return false;
    }
}
