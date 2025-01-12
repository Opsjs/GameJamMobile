using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float newVerticalPosition = 0;
    private float oldVerticalPosition = 0;
    private float highestVerticalPosition = 0;
    public float HighestVerticalPosition { get => highestVerticalPosition; }

    [Header("References")]
    [SerializeField] private GameObject cameraPointer;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private ScoreManager scoreManager;
    private Rigidbody2D rb;
    private Camera mainCamera;

    [Header("Values")]
    [SerializeField] private float smoothSpeed = 0.2f;  // Vitesse de glissement (plus petit = plus lent)
    [SerializeField] private float sensitivity;

    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;

    }
    private void Update()
    {
        float tilt = -Input.acceleration.x * sensitivity;
        if (Mathf.Abs(tilt) < .05f * sensitivity) tilt = 0;
        

        if (rb.bodyType != RigidbodyType2D.Kinematic)
        {
            transform.Translate(-tilt * Time.deltaTime * 5f, 0, 0); 
        }
        Vector3 clampedPosition = transform.position;

        float halfPlayerWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2f; 
        float cameraHalfWidth = mainCamera.orthographicSize * mainCamera.aspect;

        float minX = mainCamera.transform.position.x - cameraHalfWidth + halfPlayerWidth;
        float maxX = mainCamera.transform.position.x + cameraHalfWidth - halfPlayerWidth;

        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        transform.position = clampedPosition;
    }


    private void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(cameraTransform.position.x, Mathf.Max(transform.position.y, highestVerticalPosition), cameraTransform.position.z);

        cameraTransform.position = Vector3.Lerp(
            cameraTransform.position,
            targetPosition,
            smoothSpeed * Time.deltaTime
        );
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            Debug.Log("Player is dead");
            
            rb.linearVelocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;

            //------------------------------------------------------------------------------------
            // Ajouter script Thidiane
            //------------------------------------------------------------------------------------
        } else
        {
            oldVerticalPosition = newVerticalPosition;
            newVerticalPosition = cameraPointer.transform.position.y;
            if (newVerticalPosition > highestVerticalPosition)
            {
                highestVerticalPosition = newVerticalPosition;
                scoreManager.UpdateScore(highestVerticalPosition);
                if (highestVerticalPosition > oldVerticalPosition)
                {
                    Vector3 targetPosition = new Vector3(
                        cameraTransform.position.x,
                        newVerticalPosition,
                        cameraTransform.position.z
                    );
                }
            }
        }
    }
}