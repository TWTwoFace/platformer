using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    
    [SerializeField] private int _countOfJumps;
    [SerializeField] private int _countExtraJumps;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [Space]
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;

    public float getSpeed()
    {
        return _speed;
    }

    public int getCountOfExtraJumps()
    {
        return _countExtraJumps;
    }
    
    public float getJumpForce()
    {
        return _jumpForce;
    }
    public void ChangeSpeed(float newSpeed)
    {
        _speed = Mathf.Clamp(newSpeed, _minSpeed, _maxSpeed);
    }
    public void ChangeExtraJumps(int count)
    {
        _countExtraJumps = Mathf.Clamp(count, 0, 1);
    }
}
