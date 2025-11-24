using UnityEngine;

public class PlayerSFXController : MonoBehaviour
{
    // SFX master
    [SerializeField] private SFXMaster sfx;

    // Is there an enemy in the reticle? (Controls sound only playing when hitting an enemy)
    private bool targeted = false;
    // Current enemy targeted
    private GameObject enemy;
    // Player animator
    private Animator animator;

    void Awake()
    {
        // Fetch SFX master
        if(sfx == null) { sfx = GameObject.Find("SFXMaster").GetComponent<SFXMaster>(); }

        // Fetch animator
        animator = transform.parent.GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag.Equals("Enemy")) {
            targeted = true;
            if(enemy == null) { enemy = collider.gameObject; }
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.tag.Equals("Enemy")) {
            targeted = true;
            if(enemy == null) { enemy = collider.gameObject; }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.tag.Equals("Enemy"))
        {
            if(targeted)
            {
                Debug.Log("Miss!");
                animator.SetTrigger("Miss");
                animator.ResetTrigger("Left");
                animator.ResetTrigger("Down");
                animator.ResetTrigger("Up");
                animator.ResetTrigger("Right");
                sfx.PlayMiss();
                targeted = false;
                enemy = null;
            }
        }
    }

    public void PlayShield() {
        sfx.PlayShield();
        targeted = false;
        Destroy(enemy);
    }
    public void PlaySword() {
        sfx.PlaySword();
        targeted = false;
        Destroy(enemy);
    }
    public void PlayHammer() {
        sfx.PlayHammer();
        targeted = false;
        Destroy(enemy);
    }
    public void PlaySpear() {
        sfx.PlaySpear();
        targeted = false;
        Destroy(enemy);
    }

    public bool GetTargeted() { return targeted; }
}
