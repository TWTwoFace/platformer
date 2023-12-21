using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _health;



    public void TakeDamage(float damage)
    {
        if (damage > 0)
        {
            _health -= damage;
        }
        if (_health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
