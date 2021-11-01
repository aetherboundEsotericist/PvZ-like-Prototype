using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for Grid objects, where the player can place and drag turrets
public class GridScript : MonoBehaviour
{
    [SerializeField] public bool isOccupied = false;
    [SerializeField] public bool isSpawner = false;

    void FixedUpdate()
    {
        // Uses an OverlapBox to check if there's an Enemy or Turret colliding with this Grid, turrets cannot be placed when isOccupied is true
        LayerMask mask = LayerMask.GetMask("Enemies", "Turrets");
        Collider[] colliderList = Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.identity, mask);
        if(colliderList.Length != 0) isOccupied = true;
        else isOccupied = false;
    }

    // Shows the OverlapBox in the editor.
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}