using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Enemy spawnpoint (assigned in heirarchy)
    [SerializeField] private GameObject spawnpoint;

    // Player reticle (assigned in heirarchy)
    [SerializeField] private GameObject reticle;

    // Enemy prefabs (assigned in heirarchy)
    [SerializeField] private GameObject[] enemyPrefab;

    // Currently-spawned enemies
    private GameObject[] enemyList;

    // How fast to spawn enemies
    private float bpm;
    private float currentTime;
    [SerializeField] private float scrollRate = 1f;

    // int = index, float = milliseconds that the enemy needs to be hit at
    private List<(int, float)> EnemySpawnInfo = new List<(int, float)>();
    private float StartTime;
    private float EnemyTime;

    private void SetEnemyTime()
    {
        // Distance between enemy spawnpoint and player reticle
        float distance = Mathf.Abs(spawnpoint.transform.position.x - reticle.transform.position.x);

        // The time it should take for the enemy to move to the reticle from its spawnpoint
        if (scrollRate != 0) { EnemyTime = bpm / 60f / scrollRate; }
        else { EnemyTime = bpm / 60f; }
    }

    void Awake()
    {// Check if there are any enemies to spawn
        if (enemyPrefab == null || enemyPrefab.Length == 0)
        {
            Debug.LogError("No enemies assigned!");
        }

        // Check if the BPM has been set
        SongInfo songInfo = GameObject.FindObjectOfType<SongInfo>();
        if (songInfo == null)
        {
            Debug.Log("BPM not found; default BPM used.");
            bpm = 160f;
        }
        else { bpm = songInfo.GetBPM(); }

        // Set timer
        ResetTimer();

        InitializeEnemyList();
        SetEnemyTime();
        StartTime = Time.deltaTime;
        currentTime = StartTime + EnemySpawnInfo[0].Item2 - EnemyTime * 1.2f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("currentTime: " + currentTime + "\nTime.deltaTime: " + Time.time);
        // Update time
        currentTime -= Time.deltaTime;
        if (currentTime <= Time.time)
        {
            if (EnemySpawnInfo.Count != 0)
            {
                SpawnEnemy(EnemySpawnInfo[0].Item1);
                SetEnemyTime();

                EnemySpawnInfo.RemoveAt(0);
                if (EnemySpawnInfo.Count != 0)
                    currentTime = StartTime + EnemySpawnInfo[0].Item2 - EnemyTime;
            }
        }

    }

    // Spawn a random enemy from the list
    private void SpawnEnemy(int index = -1)
    {
        // 0 = armor, 1 = mage, 2 = shield, 3 = sword
        /*if (index == -1)
        {
            // The index of the random enemy to spawn
            index = Random.Range(0, enemyPrefab.Length);
        }*/

        // The position to spawn the random enemy
        Vector3 pos;
        if (spawnpoint == null) { pos = new Vector3(15, -2, 0); }
        else { pos = spawnpoint.transform.position; }

        // Spawn the enemy
        GameObject enemy = Instantiate(enemyPrefab[index], pos, enemyPrefab[index].transform.rotation, this.transform);

        // Distance between enemy spawnpoint and player reticle
        float distance = Mathf.Abs(spawnpoint.transform.position.x - reticle.transform.position.x);

        // The time it should take for the enemy to move to the reticle from its spawnpoint
        float time;
        if (scrollRate != 0) { time = bpm / 60f / scrollRate; }
        else { time = bpm / 60f; }

        // Set enemy speed
        float speed = distance / time;
        enemy.GetComponent<EnemyController>().SetSpeed(speed);
    }

    private void InitializeEnemyList()
    {
        // 0 = armor, 1 = mage, 2 = shield, 3 = sword
        //EnemySpawnInfo.Add((1, 1.0f));
        //EnemySpawnInfo.Add((2, 5.0f));

        EnemySpawnInfo.Add((1, 6.14f));
        EnemySpawnInfo.Add((1, 7.48f));
        EnemySpawnInfo.Add((1, 8.93f));
        EnemySpawnInfo.Add((1, 10.23f));
        EnemySpawnInfo.Add((3, 11.38f));
        EnemySpawnInfo.Add((3, 12.1f));
        EnemySpawnInfo.Add((3, 12.88f));
        EnemySpawnInfo.Add((3, 13.62f));
        EnemySpawnInfo.Add((0, 14.3f));

        EnemySpawnInfo.Add((2, 16.96f));
        EnemySpawnInfo.Add((3, 17.52f));
        EnemySpawnInfo.Add((3, 18.23f));
        EnemySpawnInfo.Add((3, 18.87f));
        EnemySpawnInfo.Add((3, 19.61f));
        EnemySpawnInfo.Add((0, 20.77f));

        EnemySpawnInfo.Add((1, 22.11f));
        EnemySpawnInfo.Add((2, 22.97f));
        EnemySpawnInfo.Add((1, 23.4f));
        EnemySpawnInfo.Add((2, 24.29f));
        EnemySpawnInfo.Add((1, 24.71f));
        EnemySpawnInfo.Add((2, 25.56f));
        EnemySpawnInfo.Add((1, 26.0f));
        EnemySpawnInfo.Add((0, 27.02f));


        EnemySpawnInfo.Add((3, 28.0f));
        EnemySpawnInfo.Add((3, 29.3f));
        EnemySpawnInfo.Add((3, 30.6f));
        EnemySpawnInfo.Add((0, 32.8f));

        EnemySpawnInfo.Add((2, 34.3f));
        EnemySpawnInfo.Add((2, 34.8f));
        EnemySpawnInfo.Add((2, 35.6f));
        EnemySpawnInfo.Add((2, 36.2f));
        EnemySpawnInfo.Add((2, 36.9f));
        EnemySpawnInfo.Add((2, 37.6f));
        EnemySpawnInfo.Add((2, 38.2f));
        EnemySpawnInfo.Add((2, 38.9f));
        EnemySpawnInfo.Add((2, 39.5f));
        EnemySpawnInfo.Add((2, 40.2f));
        EnemySpawnInfo.Add((2, 40.9f));
        EnemySpawnInfo.Add((2, 41.6f));
        EnemySpawnInfo.Add((2, 42.2f));
        EnemySpawnInfo.Add((2, 42.9f));

        EnemySpawnInfo.Add((3, 43.5f));
        EnemySpawnInfo.Add((3, 44.8f));
        EnemySpawnInfo.Add((3, 46.2f));
        EnemySpawnInfo.Add((3, 46.8f));
        EnemySpawnInfo.Add((3, 47.5f));
        EnemySpawnInfo.Add((3, 48.0f));
        EnemySpawnInfo.Add((0, 48.8f));

        // 0 = armor, 1 = mage, 2 = shield, 3 = sword
        EnemySpawnInfo.Add((2, 50.3f));
        EnemySpawnInfo.Add((2, 51.6f));
        EnemySpawnInfo.Add((2, 52.9f));
        EnemySpawnInfo.Add((1, 54.17f));
        EnemySpawnInfo.Add((2, 55.5f));
        EnemySpawnInfo.Add((3, 56.1f));
        EnemySpawnInfo.Add((2, 56.8f));
        EnemySpawnInfo.Add((3, 57.4f));
        EnemySpawnInfo.Add((2, 58.1f));
        EnemySpawnInfo.Add((3, 58.9f));
        EnemySpawnInfo.Add((2, 59.6f));
        EnemySpawnInfo.Add((3, 60.2f));
        EnemySpawnInfo.Add((3, 60.8f));
        EnemySpawnInfo.Add((3, 61.1f));
        EnemySpawnInfo.Add((3, 61.5f));
        EnemySpawnInfo.Add((2, 62.3f));
        EnemySpawnInfo.Add((3, 62.7f));
        EnemySpawnInfo.Add((3, 63.5f));
        EnemySpawnInfo.Add((3, 64.1f));
        EnemySpawnInfo.Add((0, 64.8f));

        EnemySpawnInfo.Add((3, 66.0f));
        EnemySpawnInfo.Add((3, 67.5f));
        EnemySpawnInfo.Add((3, 68.1f));
        EnemySpawnInfo.Add((3, 68.8f));
        EnemySpawnInfo.Add((1, 69.1f));
        EnemySpawnInfo.Add((1, 69.5f));
        EnemySpawnInfo.Add((3, 70.3f));
        EnemySpawnInfo.Add((3, 71.4f));
        EnemySpawnInfo.Add((3, 72.9f));
        EnemySpawnInfo.Add((3, 73.5f));
        EnemySpawnInfo.Add((3, 74.1f));
        EnemySpawnInfo.Add((3, 74.8f));
        EnemySpawnInfo.Add((2, 75.6f));
        EnemySpawnInfo.Add((3, 76.1f));
        EnemySpawnInfo.Add((3, 76.7f));
        EnemySpawnInfo.Add((3, 77.4f));
        EnemySpawnInfo.Add((3, 76.8f));
        EnemySpawnInfo.Add((2, 79.0f));
        EnemySpawnInfo.Add((3, 89.3f));
        EnemySpawnInfo.Add((3, 79.7f));
        EnemySpawnInfo.Add((3, 80.1f));
        EnemySpawnInfo.Add((2, 80.8f));
        EnemySpawnInfo.Add((2, 81.5f));
        EnemySpawnInfo.Add((2, 82.2f));
        EnemySpawnInfo.Add((3, 82.5f));
        EnemySpawnInfo.Add((2, 83.0f));
        EnemySpawnInfo.Add((3, 83.6f));
        EnemySpawnInfo.Add((3, 84.2f));
        EnemySpawnInfo.Add((3, 84.9f));
        EnemySpawnInfo.Add((3, 85.2f));
        EnemySpawnInfo.Add((3, 85.6f));
        EnemySpawnInfo.Add((0, 86.2f));
    }

    // Reset the timer to its starting time
    // Controls when enemies are spawned, NOT how fast they move
    private void ResetTimer()
    {
        Debug.Log("Step");
        currentTime = bpm / 60f;
    }
}
