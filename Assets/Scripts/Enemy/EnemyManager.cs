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

    void Awake()
    {// Check if there are any enemies to spawn
        if(enemyPrefab == null || enemyPrefab.Length == 0) {
            Debug.LogError("No enemies assigned!");
        }

        // Check if the BPM has been set
        SongInfo songInfo = GameObject.FindObjectOfType<SongInfo>();
        if(songInfo == null) {
            Debug.Log("BPM not found; default BPM used.");
            bpm = 160f;
        }
        else { bpm = songInfo.GetBPM(); }

        // Set timer
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        // Update time
        currentTime -= Time.deltaTime;
        if(currentTime < 0) {
            ResetTimer();
            SpawnEnemy();
        }
    }

    // Spawn a random enemy from the list
    private void SpawnEnemy()
    {
        // The index of the random enemy to spawn
        int index = Random.Range(0, enemyPrefab.Length);

        // The position to spawn the random enemy
        Vector3 pos;
        if(spawnpoint == null) { pos = new Vector3(15, -2, 0); }
        else { pos = spawnpoint.transform.position; }

        // Spawn the enemy
        GameObject enemy = Instantiate(enemyPrefab[index], pos, enemyPrefab[index].transform.rotation, this.transform);

        // Distance between enemy spawnpoint and player reticle
        float distance = Mathf.Abs(spawnpoint.transform.position.x - reticle.transform.position.x);

        // The time it should take for the enemy to move to the reticle from its spawnpoint
        float time;
        if(scrollRate != 0) { time = bpm / 60f / scrollRate; }
        else { time = bpm / 60f; }

        // Set enemy speed
        enemy.GetComponent<EnemyController>().SetSpeed(distance/time);
    }

    // Reset the timer to its starting time
    // Controls when enemies are spawned, NOT how fast they move
    private void ResetTimer()
    {
        Debug.Log("Step");
        currentTime = bpm / 60f;
    }
}
