using UnityEngine;

public class EnemyBehaviourCloser : IState
{
    private EnemyMovement _enemyMovement;
    public EnemyBehaviourCloser(EnemyMovement enemyMovement)
    {
        _enemyMovement = enemyMovement;
    }
    public void Enter()
    {
        Debug.Log("Closer enter");
    }

    public void Exit()
    {
        Debug.Log("Closer exit");
    }

    public void Update(Transform obj = null)
    {
        Debug.Log("Closer updates");
        _enemyMovement.GetCloserToPlayer(obj);
    }
}
