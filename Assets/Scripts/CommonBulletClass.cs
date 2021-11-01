using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Common class for Bullet objects
public class CommonBulletClass : MonoBehaviour
{
    public int damage = 2;
    public int speed = 3;
    public int knockback = 2;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Moves the bullet from right to left
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy") // Bullets can only collide with enemies as by project settings, but it's good to check regardless
        {
            other.rigidbody.AddForce(Vector3.back * knockback, ForceMode.Impulse); // Knocks enemy back
            other.gameObject.GetComponent<EnemyClass>().health -= damage; // Damages enemy
            Destroy(gameObject); // Destroys the bullet
        }
    }
    
    private void OnBecameInvisible() // Offscreen bullets should be destroyed
    {
        Destroy(gameObject);
    }
}