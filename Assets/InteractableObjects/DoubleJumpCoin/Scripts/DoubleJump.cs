using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    [SerializeField] private int _jumpsCount;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerStats>(out PlayerStats player))
        {
            player.ChangeJumps(_jumpsCount);
        }
        Destroy(this.gameObject);
    }
}
