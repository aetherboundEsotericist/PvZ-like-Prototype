using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Specialized class for the Laser projectile.
public class LaserBulletClass : CommonBulletClass
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        // Laser moves too fast for transform.translate to be reliable, should use rb.AddForce instead.
        rb.AddForce(Vector3.back * Time.deltaTime * speed, ForceMode.Impulse);
    }

    // Laser is kinematic, so it should call OnTriggerEnter instead (CommonBulletClass calls OnCollisionEnter)
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Rigidbody>().AddForce(Vector3.back * knockback, ForceMode.Impulse);
            other.gameObject.GetComponent<EnemyClass>().health -= damage;
            damage -= 1; // Barely noticeable, but Laser loses some damage for every enemy it pierces.
            if (damage <= 0) Destroy(gameObject); // Laser should be destroyed only when its damage falls to 0 or when it's offscreen
        }
    }
}