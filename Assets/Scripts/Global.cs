using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

// Global script that handles general game interactions
public class Global : MonoBehaviour
{
    [SerializeField] public int credits = 0;
    [SerializeField] public TextMeshProUGUI textCredits;
    [SerializeField] public TextMeshProUGUI textGameOver;
    [SerializeField] public TextMeshProUGUI textStats;
    [SerializeField] public List<EnemySpawnpoint> enemySpawners;
    [SerializeField] float globalEnemyCooldown = 6;
    public int totalEnemies = 100;
    public int spawnedEnemies = 0;

    void Start()
    {
        StartCoroutine(SpawnInRandomLane(enemySpawners));
    }
    void Update()
    {
        textCredits.SetText("Credits: " + credits); // Shows how many Credits the player has

        spawnedEnemies = 0; // resets spawnedEnemies before it's updated and displayed
        foreach(EnemySpawnpoint spawners in enemySpawners) // Sums all spawners' spawnCount values
        {
            spawnedEnemies += spawners.spawnCount;
        }
        textStats.SetText("Enemies Left: " + (totalEnemies - spawnedEnemies)); // Display total enemies left

        // Restarts the scene
        if(Input.GetKeyDown(KeyCode.R))
        {
            Scene activeScene = SceneManager.GetActiveScene();
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(activeScene.name);
        }

        // Ultra fast spawning after the 70th enemy
        if(spawnedEnemies >= 70) globalEnemyCooldown = 1f;
    }

    // Game Over handler, pauses the game and locks your mouse
    public void GameOver()
    {
        textGameOver.SetText("Game Over!\n[R]estart?");
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("Game Over!!!");
    }

    // Controls spawning. Enemies are spawned by Spawners with the EnemySpawnpoint script.
    IEnumerator SpawnInRandomLane(List<EnemySpawnpoint> spawnerList)
    {
        while(spawnedEnemies < totalEnemies)
        {
            StartCoroutine(spawnerList[Random.Range(0, enemySpawners.Count)].SpawnEnemy());
            if(globalEnemyCooldown > 2f) globalEnemyCooldown -= 0.12f;
            yield return new WaitForSeconds(globalEnemyCooldown);
        }      
    }
}