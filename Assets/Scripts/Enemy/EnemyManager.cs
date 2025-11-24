using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Enemy spawnpoint (assigned in heirarchy)
    [SerializeField] private GameObject spawnpoint;

    // Enemy prefabs (assigned in heirarchy)
    [SerializeField] private GameObject[] enemyPrefab;

    // Currently-spawned enemies
    private GameObject[] enemyList;

    // How fast to spawn enemies
    private float bpm;
    private float currentTime;

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
        enemy.GetComponent<EnemyController>().SetSpeed(bpm / 4f);
    }

    // Reset the timer to its starting time
    private void ResetTimer()
    {
        Debug.Log("Step");
        currentTime = bpm / 60f / 4f;
    }
}
