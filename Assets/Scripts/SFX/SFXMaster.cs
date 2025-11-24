using UnityEngine;
using UnityEngine.Events;

public class SFXMaster : MonoBehaviour
{
    [SerializeField] private AudioSource shieldHit;
    [SerializeField] private AudioSource swordHit;
    [SerializeField] private AudioSource hammerHit;
    [SerializeField] private AudioSource spearHit;
    [SerializeField] private AudioSource missSource;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayShield()
    {
        Debug.Log("Shield hit");
        shieldHit.Play();
    }

    public void PlaySword()
    {
        Debug.Log("Sword hit");
        swordHit.Play();
    }

    public void PlayHammer()
    {
        Debug.Log("Hammer hit");
        hammerHit.Play();
    }

    public void PlaySpear()
    {
        Debug.Log("Spear hit");
        spearHit.Play();
    }

    public void PlayMiss()
    {
        Debug.Log("Miss sound");
        missSource.Play();
    }
}
