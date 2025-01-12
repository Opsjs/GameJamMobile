using UnityEngine;

public class BreakablePlatform : Platform
{
    private bool isBroken = false;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (collision.gameObject.CompareTag("Player") && !isBroken && collision.relativeVelocity.y <= 0)
        {
            isBroken = true;
            Destroy(gameObject, 0.5f); 
        }
    }
}
