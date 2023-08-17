using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float attackRange = 3.0f;
    public float patrolDistance = 5.0f;
    public float patrolSpeed = 2.0f;
    public float chaseSpeed = 3.0f;

    private float CurrentSpeed
    {
        get
        {
            if (_currentState == EnemyState.Patrol) return patrolSpeed;
            else if (_currentState == EnemyState.Chase) return chaseSpeed;
            return 0;
        }
    }

    private Vector3 _initialPosition;
    private Animator _anim;
    private enum EnemyState { Patrol, Chase, Attack }
    private EnemyState _currentState;

    private void Start()
    {
        _initialPosition = transform.position;
        _anim = GetComponentInChildren<Animator>();
        SetState(EnemyState.Patrol);
    }

    private void Update()
    {
        if (player == null) return;
        float playerDistance = Vector3.Distance(transform.position, player.position);

        if (playerDistance <= attackRange)
        {
            SetState(EnemyState.Attack);
        }
        else if (playerDistance <= patrolDistance)
        {
            SetState(EnemyState.Chase);
        }
        else
        {
            SetState(EnemyState.Patrol);
        }

        switch (_currentState)
        {
            case EnemyState.Patrol:
                Patrol();
                break;
            case EnemyState.Chase:
                ChasePlayer();
                break;
            case EnemyState.Attack:
                Attack();
                break;
        }
    }

    private void SetState(EnemyState newState)
    {
        if (_currentState != newState)
        {
            _currentState = newState;

            _anim.SetBool("Walk", false);
            _anim.SetBool("Attack", false);
        }
    }

    private void Patrol()
    {
        Vector3 targetPosition = new Vector3(_initialPosition.x + patrolDistance, _initialPosition.y, _initialPosition.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, CurrentSpeed * Time.deltaTime);

        if (transform.position.x > targetPosition.x)
        {
            transform.localScale = Vector3.one;
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            float temp = patrolDistance;
            patrolDistance = -temp;
        }

        _anim.SetBool("Walk", true);
    }

    private void ChasePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, CurrentSpeed * Time.deltaTime);


        if (transform.position.x > player.position.x)
        {
            transform.localScale = Vector3.one;
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void Attack()
    {
        _anim.SetBool("Walk", false);
        _anim.SetBool("Attack", true);
    }
}
