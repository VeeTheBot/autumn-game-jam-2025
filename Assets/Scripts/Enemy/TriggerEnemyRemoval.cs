using UnityEngine;

public class TriggerEnemyRemoval : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag.Equals("Enemy"));
        {
            Debug.Log("Enemy off-screen; remove it.");

            Destroy(collider.gameObject);
        }
    }
}
