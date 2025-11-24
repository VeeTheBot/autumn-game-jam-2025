using UnityEngine;

public class EnvironmentScroll : MonoBehaviour
{
    // The song's BPM
    private float bpm;

    // The scroll rate of the environmental object
    [SerializeField] private float scrollRate = 1f;

    [SerializeField] private float spriteWidth;
    private Vector3 startPosition;

    void Awake()
    {
        // Check if the BPM has been set
        SongInfo songInfo = GameObject.FindObjectOfType<SongInfo>();
        if(songInfo == null) {
            Debug.Log("BPM not found; default BPM used.");
            bpm = 160f;
        }
        else { bpm = songInfo.GetBPM(); }

        if(spriteWidth == 0) {
            spriteWidth = 1000;
        }

        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * bpm / 4f / 2f * scrollRate * Time.deltaTime);

        // If the element is off-screen, move it back on screen
        if(transform.position.x < startPosition.x - (spriteWidth/100f * 2.5f))
        {
            transform.position = startPosition;
        }
    }
}
