using UnityEngine;

public class EnvironmentScroll : MonoBehaviour
{
    // The song's BPM
    private float bpm;

    // The scroll rate of the environmental object
    [SerializeField] private float scrollRate = 1f;

    void Awake()
    {
        // Check if the BPM has been set
        SongInfo songInfo = GameObject.FindObjectOfType<SongInfo>();
        if(songInfo == null) {
            Debug.Log("BPM not found; default BPM used.");
            bpm = 160f;
        }
        else { bpm = songInfo.GetBPM(); }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - bpm / 4f / 2f * scrollRate * Time.deltaTime, transform.position.y, transform.position.z);
    }
}
