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


    [HideInInspector] public Vector3 enemyPosition;
    private Vector3 initalPosition;

    [Header("Teleport Informations")]
    public Vector2 boxSize;
    public List<Enemy> enemies;
    [SerializeField] private float xOffset;
    public bool inTeleportTime;

    [Header("Spell Informations")]
    [SerializeField] private GameObject spellPrefab;
    public int amountOfSpells;
    public float spellCooldown;
    [SerializeField] private int yOffset;

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
            idleState,
            normalAttackState,
            idleState,
            criticalAttackState,
            idleState,
            spellCastState,
            idleState,
            teleportState,
            criticalAttackState,
            teleportState,
            idleState,
        };

        isInitialTime = true;
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();

        if (currentStateIndex == heroStates.Count)
            currentStateIndex = 0;
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

        enemyPosition = new Vector3(enemy.position.x, enemy.position.y, facingDirectionEnemy);
    }

    public void TeleportToPosition()
    {
        if (inTeleportTime == true)
        {
            FindAllEnemiesInArea(transform.position);
            RandomPosition();

            initalPosition = transform.position;

            if (enemyPosition.z == -1)
            {
                Flip();

                transform.position = new Vector3(enemyPosition.x + xOffset, enemyPosition.y);
            }
            else
            {

                transform.position = new Vector3(enemyPosition.x - xOffset, enemyPosition.y);
            }
        } else
        {

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


    public void MostarMovement()
    {
        if (IsEnemyDetected())
        {
            stateMachine.ChangeState(heroStates[currentStateIndex]);
        }
        else
        {
            stateMachine.ChangeState(moveState);
        }
    }
}
