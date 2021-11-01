using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Specialized class for Turrets
public class TurretClass : CommonClass
{
    [SerializeField] GameObject selectedBullet; // This turret's bullet. Must be set through the Editor
    public bool hasLineOfSight = false;
    void Start()
    {
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            StartCoroutine(Die());
        }
    }

    void OnCollisionEnter(Collision other)
    {
        // Starts firing once you move it into the Grid
        if(other.gameObject.tag == "Grid") hasLineOfSight = true;
    }

    IEnumerator Fire()
    {
        while(true)
        {
            if(hasLineOfSight)
            {
                Instantiate(selectedBullet, transform.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(cooldown);
        }
    }
}