using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    

    [SerializeField] private GameObject _player;

    [SerializeField] private float _followDelta;

    private PlayerStats _playerStats;
    private Transform _followTransform;

    private void Start()
    {
        _followTransform = _player.GetComponent<Transform>();
        _playerStats = _player.GetComponent<PlayerStats>();
    }

    private void Update()
    {
        if(Mathf.Abs(transform.position.x - _followTransform.position.x) > _followDelta)
        {
            float x;
            if(_followTransform.position.x < transform.position.x)
                x = _followTransform.position.x + _followDelta;
            else
                x = _followTransform.position.x - _followDelta;
            
            transform.position = Vector3.Lerp(transform.position, new Vector3(x, transform.position.y, transform.position.z), _playerStats.getSpeed() * Time.deltaTime);
        }
    }
}
