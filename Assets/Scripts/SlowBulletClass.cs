using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Specialized class for Slow Bullet
public class SlowBulletClass : CommonBulletClass
{
    [SerializeField] public float slowValue = 1;
    [SerializeField] public float slowDuration = 3;
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            EnemyClass enemy = other.gameObject.GetComponent<EnemyClass>();
            enemy.StartCoroutine(enemy.Slowdown(slowValue, slowDuration)); // Slow effects are handled by EnemyClass
            enemy.health -= damage;
            Debug.Log("dealt damage, enemy is at " + enemy.health + "health");
            Destroy(gameObject);
        }
    }
}