using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("StaticPlatform") || 
            collision.collider.CompareTag("MovingPlatform") ||
            collision.collider.CompareTag("BreakablePlatform"))
        {
            Destroy(collision.gameObject);
        }
    }
}
