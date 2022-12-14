using System;
using UnityEngine;

namespace Enemy
{
    public class FollowState : IEnemyState
    {
        private Rigidbody rig;
        private void Start()
        {
            rig = GetComponent<Rigidbody>();
        }

        public FollowState()
        {
            enemyState = EnemyStates.FollowPlayer;
        }
        public override void Invoke(EnemyControler currentEnemy)
        {
            currentEnemy.animator.SetBool("isRunning", true);
            currentEnemy.animator.SetBool("isWalking", false);
            currentEnemy.animator.SetBool("isDead", false);
            currentEnemy.animator.SetBool("isAttacking", false);

            currentEnemy.GoToDirection(Vector3.Scale(currentEnemy.playerPosition.position - currentEnemy.transform.position, new Vector3(1,0,1)));
        }
    }
}