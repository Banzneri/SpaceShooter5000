using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy {
    private float _health;
    private EnemyState _currentState;

    public EnemyState CurrentState
    {
        get { return _currentState; }
        set { _currentState = value; }
    }

    public void RunState()
    {
        _currentState.OnUpdate();
    }

    public void ChangeState(EnemyState newState)
    {
        _currentState.OnExit();
        _currentState = newState;
        _currentState.OnEnter();
    }
}
