using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Rigidbody to move
    private Rigidbody2D rigidbody;

    // How fast the enemy moves (affected by scroll speed)
    private float speed;

    // Removal trigger
    private GameObject removalTrigger;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Fetch the rigidbody
        rigidbody = GetComponent<Rigidbody2D>();

        // Fetch the removal trigger
        removalTrigger = GameObject.FindWithTag("TriggerEnemy");
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.linearVelocity = speed * (new Vector2(-1, 0)).normalized;

        // Despawn the enemy if it's moving so fast it skips the removal trigger
        if(transform.position.x < removalTrigger.transform.position.x) {
            Debug.Log("Skipped trigger; delete enemy.");
            Destroy(gameObject);
        }
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
