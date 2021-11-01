using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for the ghost objects that spawn enemies
public class EnemySpawnpoint : MonoBehaviour
{
    [SerializeField] public int spawnCount = 0;
    
    // Holds this spawner's enemy pool, each spawner can have it's own list that is set from the editor.
    // There are special interactions with the enemy in the first position (enemyList[0])
    [SerializeField] public List<GameObject> enemyList;

    void Start()
    {

    }

    public IEnumerator SpawnEnemy()
    {
        {
            // First 3 enemies are always pulled from position 0
            if(spawnCount <= 3)
            {
                Instantiate(enemyList[0], transform.position, Quaternion.identity);
            }

            // Spawn randomly from the entire pool until the tenth spawn
            else if(spawnCount <= 10)
            {
                int spawnNumber = Random.Range(0,  enemyList.Count);
                Instantiate(enemyList[spawnNumber], transform.position, Quaternion.identity);
            }

            // Spawn randomly excluding the enemy in position 0
            else
            {
                int spawnNumber = Random.Range(1,  enemyList.Count);
                Instantiate(enemyList[spawnNumber], transform.position, Quaternion.identity);
            }
            spawnCount++;
            yield return new WaitForSeconds(0.5f);
        }
    }
}