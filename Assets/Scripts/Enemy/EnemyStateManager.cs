using System;
using System.Collections.Generic;
using Enemy.States;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

namespace Enemy
{
    public class EnemyStateManager
    {
        private readonly Dictionary<EnemyStates, IEnemyState> _states = new();
        private IEnemyState _currentState;
        public bool didAttack = false;
        public bool shouldLeftAttack = false;

        public EnemyStateManager(List<IEnemyState> inputStates)
        {
            foreach (var state in inputStates)
            {
                _states.Add(state.enemyState, state);
            }

            _currentState = _states[EnemyStates.Standby];
        }
        public void SetState(EnemyStates newState)
        {
            if (_currentState.enemyState != EnemyStates.Death)
            {
                didAttack = false;
                shouldLeftAttack = false;
                _currentState = _states[newState];
            }
        }

        public IEnemyState GetCurrentState()
        {
            return _currentState;
        }

        public void Invoke(EnemyControler currentEnemy)
        {
            _currentState.Invoke(currentEnemy);
            
        }

        public bool IsStunned()
        {
            if (_currentState.enemyState == EnemyStates.Stun)
            {
                return true;
            }
            return false;
        }

        public bool IsProvoked()
        {
            if (_currentState.enemyState == EnemyStates.Standby)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsDeath()
        {
            if (_currentState.enemyState == EnemyStates.Death)
            {
                return true;
            }

            return false;
        }

        public bool IsProvokedAndNotStunned()
        {
            return IsProvoked() && !IsStunned();
        }

        public bool IsProvokedAndNotStunnedAndNotDead()
        {
            return IsProvokedAndNotStunned() && !IsDeath();
        }
    }
}