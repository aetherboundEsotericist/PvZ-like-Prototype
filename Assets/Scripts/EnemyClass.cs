using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Specialized class for Enemies
public class EnemyClass : CommonClass
{
    [SerializeField] public int damage = 1;
    [SerializeField] public float speed = 0.5f;
    Rigidbody rb;

    void Update()
    {
        if (health <= 0)
        {
            StartCoroutine(Die());
        }

        transform.Translate(Vector3.forward * Time.deltaTime * speed); // Moves forward
    }

    void OnCollisionEnter(Collision other)
    {
        // If enemy collides with a turret:
        if(other.gameObject.tag == "Placeable")
        {
            StartCoroutine(Attack(other.gameObject.GetComponent<TurretClass>()));
        }

        // If enemy reaches the end point
        if(other.gameObject.tag == "GameOver")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<Global>().GameOver();
        }
    }

    IEnumerator Attack(TurretClass target)
    {
        target.health -= damage;
        //Debug.Log("turret received damage! current health: " + target.health);
        yield return new WaitForSeconds(1);
    }

    public IEnumerator Slowdown(float slowValue, float slowDuration) // Slow effects handler, this Coroutine is called by Slow Bullet
    {
        //Debug.Log("Slow activated, Potency " + slowValue + ", Duration " + slowDuration);
        float originalSpeed = speed;
        speed -= slowValue;
        if(speed < 0)
        {
            speed = 0;
        }
        yield return new WaitForSeconds(slowDuration);
        Debug.Log("reaching this");
        speed = originalSpeed;
    }
}