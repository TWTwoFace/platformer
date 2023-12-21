using UnityEngine;

public class EnemyBehaviourAttack : IEnemyState
{
    public void Enter()
    {
        Debug.Log("Attack enter");
    }

    public void Exit()
    {
        Debug.Log("Attack exit");
    }

    public void Update()
    {
        Debug.Log("Attack exit");
    }
}
