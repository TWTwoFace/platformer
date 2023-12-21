using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    private EnemyMovement _enemyMovement;
    private Dictionary<Type, IState> _enemyBehaviours;
    private IState _currentState;
    private Transform _updateParam = null;

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
        _currentState?.Update(_updateParam);
    }

    private void InitStates()
    {
        _enemyBehaviours = new Dictionary<Type, IState>();
        _enemyBehaviours[typeof(EnemyBehaviourPatrol)] = new EnemyBehaviourPatrol(_enemyMovement);
        _enemyBehaviours[typeof(EnemyBehaviourCloser)] = new EnemyBehaviourCloser(_enemyMovement);
        _enemyBehaviours[typeof(EnemyBehaviourAttack)] = new EnemyBehaviourAttack();
    }

    private void SetBehaviour(IState behaviour)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
            _updateParam = null;
        }
        _currentState = behaviour;
        _currentState.Enter();
    }

    private IState GetBehaviour<T>() where T : IState
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
        var behaviour = GetBehaviour<EnemyBehaviourCloser>();
        SetBehaviour(behaviour);
        _updateParam = player;
    }
    public void SetAttackBehaviour()
    {
        var behaviour = GetBehaviour<EnemyBehaviourAttack>();
        SetBehaviour(behaviour);
    }
}
