using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private BoxCollider2D _bc;

    [SerializeField] private float _damage;
    [SerializeField] private float _attackInterval;
    [SerializeField] private float _attackForce;

    private float _attackTimer;
    private bool _canAttack => _attackTimer <= 0;

    private void Start()
    {
        _attackTimer = 0f;
        _bc = GetComponent<BoxCollider2D>();
        _bc.enabled = false;
    }

    private void Update()
    {
        if (_attackTimer >= 0)
            _attackTimer -= Time.deltaTime;
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
            _bc.enabled = true;
        if (context.canceled)
            _bc.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyHealth>(out var enemy) && _canAttack)
        {
            enemy.TakeDamage(_damage);
            _attackTimer = _attackInterval;
            collision.gameObject.TryGetComponent<Rigidbody2D>(out var enemyRB);
            enemyRB.AddForce((transform.right + transform.up) * _attackForce, ForceMode2D.Impulse);
        }
    }
}
