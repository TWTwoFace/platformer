using UnityEngine;

public class EnemyBehaviourPatrol : IState
{
    private EnemyMovement _enemyMovement;
    public EnemyBehaviourPatrol(EnemyMovement enemyMovement)
    {
        _enemyMovement = enemyMovement;
    }

    public void Enter()
    {
        Debug.Log("Patrol Enter");
    }

    public void Exit()
    {
        Debug.Log("Patrol Exit");
    }


    public void Update(Transform obj = null)
    {
        Debug.Log("Patrol updates");
        _enemyMovement.Patrol();
    }
}
