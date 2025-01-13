using UnityEngine;

public class BreakablePlatform : Platform
{
    private bool isBroken = false;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (collision.gameObject.CompareTag("Player") && !isBroken && collision.relativeVelocity.y <= 0)
        {
            isBroken = true;
            animator.SetTrigger("Destroy");
            
        }
    }

    public void DestroyBreakablePlatform()
    {
        Destroy(gameObject);
    }
}
