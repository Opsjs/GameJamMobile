using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] private MenuGameOver menuGameOver;
    [SerializeField] Sprite UpPlayer;
    [SerializeField] Sprite DownPlayer;
    private Rigidbody2D rb;
    private Camera mainCamera;
    private SpriteRenderer spriteRenderer;

    [Header("Values")]
    [SerializeField] private float smoothSpeed = 0.2f;  // Vitesse de glissement (plus petit = plus lent)
    [SerializeField] private float sensitivity;
    [SerializeField] private float jumpForce = 10f;

    

    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = UpPlayer;

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
        if (rb.linearVelocityY < 0)
        {
            spriteRenderer.sprite = DownPlayer;
        } else
        {
            spriteRenderer.sprite = UpPlayer;
        }


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
            

            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            rb.linearVelocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;
            menuGameOver.OnPlayerDeath();
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
        if (collision.relativeVelocity.y > 0f)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
