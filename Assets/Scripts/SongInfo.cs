using UnityEngine;

public class SongInfo : MonoBehaviour
{
    [SerializeField] private float bpm;

    public float GetBPM()
    {
        return bpm;
    }
}
