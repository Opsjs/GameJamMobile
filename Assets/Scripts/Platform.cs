using UnityEngine;

public class Platform : MonoBehaviour
{
    public float jumpForce = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // V�rifie si la collision vient du bas (relativeVelocity.y <= 0)
        if (collision.relativeVelocity.y <= 0f)
        {
            // R�cup�re le Rigidbody2D de l'objet qui a touch� cette plateforme
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                // Modifie uniquement la composante Y de la v�locit�
                Vector2 velocity = rb.linearVelocity;
                velocity.y = jumpForce;
                rb.linearVelocity = velocity;
            }
        }
    }
}
