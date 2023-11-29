using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    private float x;

    private PlayerStats _playerStats;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerStats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        if (x != 0)
        {
            transform.Translate(new Vector2(x, 0) * _playerStats.getSpeed() * Time.deltaTime);
        }
    }

    private bool IsGrounded()
    {
        if (Mathf.Abs(_rb.velocity.y) < 0.05)
            return true;
        return false;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        x = context.ReadValue<float>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (_playerStats.getCountOfJumps() > 1)
            {
                _rb.AddForce(Vector2.up * _playerStats.getJumpForce(), ForceMode2D.Impulse);
                _playerStats.ChangeJumps(_playerStats.getCountOfJumps() - 1);
            }
            else if (IsGrounded())
            {
                _rb.AddForce(Vector2.up * _playerStats.getJumpForce(), ForceMode2D.Impulse);
            }
        }
    }
}
