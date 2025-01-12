using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] float jumpForce = 10f;
    //[SerializeField] protected Camera sceneCamera;

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {

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
