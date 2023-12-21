using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    private EnemyMovement _enemyMovement;
    private Dictionary<Type, IEnemyState> _enemyBehaviours;
    private IEnemyState _currentState;

    private void Awake()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
    }

    private void Start()
    {
        InitStates();
        SetBehaviourByDefault();
    }

    private void Update()
    {
        _currentState?.Update();
    }

    private void InitStates()
    {
        _enemyBehaviours = new Dictionary<Type, IEnemyState>();
        _enemyBehaviours[typeof(EnemyBehaviourPatrol)] = new EnemyBehaviourPatrol(_enemyMovement);
        _enemyBehaviours[typeof(EnemyBehaviourCloser)] = new EnemyBehaviourCloser(_enemyMovement);
        _enemyBehaviours[typeof(EnemyBehaviourAttack)] = new EnemyBehaviourAttack();
    }

    private void SetBehaviour(IEnemyState behaviour)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }
        _currentState = behaviour;
        _currentState.Enter();
    }

    private IEnemyState GetBehaviour<T>() where T : IEnemyState
    {
        var type = typeof(T);
        return _enemyBehaviours[type];
    }

    private void SetBehaviourByDefault()
    {
        var behaviourByDefault = GetBehaviour<EnemyBehaviourPatrol>();
        SetBehaviour(behaviourByDefault);
    }

    public void SetPatrolBehaviour()
    {
        var behaviour = GetBehaviour<EnemyBehaviourPatrol>();
        SetBehaviour(behaviour);
    }

    public void SetCloserBehaviour(Transform player)
    {
        _enemyBehaviours[typeof(EnemyBehaviourCloser)] = new EnemyBehaviourCloser(_enemyMovement, player);
        var behaviour = GetBehaviour<EnemyBehaviourCloser>();
        SetBehaviour(behaviour);
    }

    public void SetAttackBehaviour()
    {
        var behaviour = GetBehaviour<EnemyBehaviourAttack>();
        SetBehaviour(behaviour);
    }
}
