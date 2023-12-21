using UnityEngine;

public class EnemyBehaviourAttack : IState
{
    public void Enter()
    {
        Debug.Log("Attack enter");
    }

    public void Exit()
    {
        Debug.Log("Attack exit");
    }

    public void Update(Transform obj = null)
    {
        Debug.Log("Attack exit");
    }
}
