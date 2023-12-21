using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    private EnemyStateMachine _ESM;

    private void Awake()
    {
        _ESM = GetComponentInParent<EnemyStateMachine>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("q");
        if(collision.TryGetComponent<PlayerStats>(out var player))
        {
            _ESM.SetCloserBehaviour(collision.gameObject.GetComponent<Transform>());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _ESM.SetPatrolBehaviour();
    }
}
