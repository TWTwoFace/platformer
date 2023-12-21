using UnityEngine;

[RequireComponent(typeof(Transform))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _offset_x;
    [Space, SerializeField] private float _enemySpeed;
    [SerializeField] private float _attackDistance; // »—œ–¿¬»“‹ Ì‡ EnemyStats (ﬂ ‰ÛÏ‡˛)

    private Vector3 _targetPosition;
    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _targetPosition = new Vector3(_transform.position.x + _offset_x, transform.position.y, transform.position.z);
    }

    private void ToggleTargetPointX()
    {
        _offset_x *= -1;
        _targetPosition = new Vector3(_transform.position.x + _offset_x, _transform.position.y, transform.position.z);
    }

    public void GetCloserToPlayer(Transform player)
    {
        var heading = transform.position - player.position;
        var distance = heading.magnitude;
        if (distance > _attackDistance)
        {
            _transform.position = Vector3.MoveTowards(_transform.position, new Vector3(player.position.x, transform.position.y, transform.position.z), _enemySpeed * Time.deltaTime);
        }
    }

    public void Patrol()
    {
        if (_transform.position == _targetPosition)
        {
            ToggleTargetPointX();
        }
        _targetPosition.y = _transform.position.y;
        _transform.position = Vector3.MoveTowards(_transform.position, _targetPosition, _enemySpeed * Time.deltaTime);
    }
}
