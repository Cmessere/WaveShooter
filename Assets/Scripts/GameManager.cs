using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject pauseCanvas;
    public EnemySpawner waveSpawner;
    public int enemyQuantity;
    public int waveCount;

    public TextMeshProUGUI waveCountText;
    public TextMeshProUGUI enemiesCountText;

    private float currentEnemies;

    void Start()
    {
        currentEnemies = waveSpawner.SpawnEnemies(enemyQuantity, waveCount);
        enemiesCountText.text = currentEnemies.ToString();
        waveCountText.text = waveCount.ToString();
    }

    void Update()
    {
        if(currentEnemies == 0)
        {
            currentEnemies = SpawnWave();
            enemiesCountText.text = currentEnemies.ToString();
        }
    }
    public void UpdatedEnemyCount()
    {
        currentEnemies--;
        enemiesCountText.text = currentEnemies.ToString();
    }

    public float SpawnWave()
    {
        waveCount++;
        waveCountText.text = waveCount.ToString();
        float spawnedEnemies = waveSpawner.SpawnEnemies(enemyQuantity, waveCount);
        return spawnedEnemies;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseCanvas.SetActive(true);
    }
    public void UnPauseGame()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
    }

}
