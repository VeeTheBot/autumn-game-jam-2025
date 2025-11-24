using UnityEngine;
using UnityEngine.Events;

public class SFXMaster : MonoBehaviour
{
    public UnityEvent missEvent = new UnityEvent();

    [SerializeField] private AudioSource missSource;

    void Awake()
    {
        missEvent.AddListener(PlayMiss);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayMiss()
    {
        Debug.Log("Miss sound");
        missSource.Play();
    }
}
