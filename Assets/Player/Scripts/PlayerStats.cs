using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int _countOfJumps;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;

    public float getSpeed()
    {
        return _speed;
    }

    public int getCountOfJumps()
    {
        return _countOfJumps;
    }
    
    public float getJumpForce()
    {
        return _jumpForce;
    }
    public void ChangeSpeed(float newSpeed)
    {
        _speed = Mathf.Clamp(newSpeed, _minSpeed, _maxSpeed);
    }
    public void ChangeJumps(int count)
    {
        _countOfJumps = Mathf.Clamp(count, 1, 3);
    }
}
