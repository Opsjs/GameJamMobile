using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float newVerticalPosition = 0;
    float oldVerticalPosition = 0;
    float highestVerticalPosition = 0;
    [SerializeField] Transform cameraTransform;
    private void Update()
    {
        float tilt = -Input.acceleration.x;
        if (tilt > 0.1f || tilt < -0.1f)
        {
            tilt = 0;
        }
            transform.Translate(-tilt, 0, 0);
        if (transform.position.x < -2.5f)
        {
            transform.position = (new Vector3(-2.5f, transform.position.y, transform.position.z));
        } else if (transform.position.x > 2.5f)
        {
            transform.position = (new Vector3(2.5f, transform.position.y, transform.position.z));
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        oldVerticalPosition = newVerticalPosition;
        newVerticalPosition = transform.position.y;
        if (newVerticalPosition > highestVerticalPosition)
        {
            highestVerticalPosition = newVerticalPosition;
            if (highestVerticalPosition > oldVerticalPosition)
            {
                cameraTransform.position = new Vector3(cameraTransform.position.x, newVerticalPosition, cameraTransform.position.z);
            }
        }
    }

}
