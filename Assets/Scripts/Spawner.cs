using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for Turret Spawners
public class Spawner : MonoBehaviour
{
    [SerializeField] int spawnCost; // Must be set through the Editor
    [SerializeField] Global globalScript;
    [SerializeField] GameObject turret; // Must also be set through the Editor
    GridScript thisGrid;
    void Start(){
        var master = GameObject.FindGameObjectWithTag("GameController");
        globalScript = master.GetComponent<Global>();
        thisGrid = GetComponent<GridScript>();
    }

    void OnMouseDown(){
        if (globalScript.credits >= spawnCost && thisGrid.isOccupied == false)
        {
            Debug.Log("spawning turret!");
            Instantiate(turret, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
            globalScript.credits -= 100;
        }
        else if (globalScript.credits < 100) Debug.Log("insufficient funds!");
    }
}
