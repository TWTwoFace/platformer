using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpeedAddCoin : MonoBehaviour
{
    [SerializeField] private float _newSpeed;
    [SerializeField] private float _seconds;

    private float _defaultSpeed;
    private bool _collected = false;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerStats>(out PlayerStats player) && !_collected)
        {
            StartCoroutine(ChangeSpeedForTime(player));
        }
    }
    
    private IEnumerator ChangeSpeedForTime(PlayerStats player)
    {
        _collected = true;
        _defaultSpeed = player.getSpeed();
        player.ChangeSpeed(_newSpeed);
        _spriteRenderer.enabled = false;
        yield return new WaitForSeconds(_seconds);
        player.ChangeSpeed(_defaultSpeed);
        Destroy(this.gameObject);
    }
}
