using UnityEngine;
using UnityEngine.Events;

public class Trap : MonoBehaviour
{
    public float bounceForce = 10f;
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerController"))
        {
            HandleDamage(collision.gameObject, collision.GetComponent<PlayerHealthController>());
            HandlePlayerBounce(collision.gameObject);
        }
    }

    private void HandlePlayerBounce(GameObject player)
    {
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        
        // Resets player y velocity
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        
        // Apply bounce force
        rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
    }

    private void HandleDamage(GameObject player, PlayerHealthController playerHealthController)
    {
        playerHealthController = player.gameObject.GetComponent<PlayerHealthController>();
        playerHealthController.Damage(damage);
    }
}
