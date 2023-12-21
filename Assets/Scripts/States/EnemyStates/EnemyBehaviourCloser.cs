using UnityEngine;

public class EnemyBehaviourCloser : IEnemyState
{
    private EnemyMovement _enemyMovement;
    private Transform _playerTransform;
    public EnemyBehaviourCloser(EnemyMovement enemyMovement, Transform playerTransform = null)
    {
        _enemyMovement = enemyMovement;
        _playerTransform = playerTransform;
    }
    public void Enter()
    {
        Debug.Log("Closer enter");
    }

    public void Exit()
    {
        Debug.Log("Closer exit");
    }

    public void Update()
    {
        Debug.Log("Closer updates");
        if(_playerTransform != null)
            _enemyMovement.GetCloserToPlayer(_playerTransform);
    }
}
