using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float newVerticalPosition = 0;
    float oldVerticalPosition = 0;
    float highestVerticalPosition = 0;
    [SerializeField] GameObject cameraPointer;
    [SerializeField] float smoothSpeed = 0.2f;  // Vitesse de glissement (plus petit = plus lent)
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
        newVerticalPosition = cameraPointer.transform.position.y;
        if (newVerticalPosition > highestVerticalPosition)
        {
            highestVerticalPosition = newVerticalPosition;
            if (highestVerticalPosition > oldVerticalPosition)
            {
                //cameraTransform.position = new Vector3(cameraTransform.position.x, newVerticalPosition, cameraTransform.position.z);
                Vector3 targetPosition = new Vector3(
                    cameraTransform.position.x,
                    newVerticalPosition,
                    cameraTransform.position.z
                );

                StartCoroutine(SmoothMoveCamera(targetPosition));
            }
        }
    }
    private System.Collections.IEnumerator SmoothMoveCamera(Vector3 targetPosition)
    {
        //float elapsedTime = 0f;
        //float duration = smoothSpeed;

        //Vector3 startPosition = cameraTransform.position;

        //while (elapsedTime < duration)
        //{
        //    // Interpoler la position de la caméra
        //    cameraTransform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);

        //    elapsedTime += Time.deltaTime;
        //    yield return null;
        //}

        //// Fixer la position finale pour éviter les imprécisions
        //cameraTransform.position = targetPosition;

        Vector3 velocity = Vector3.zero;

        while (Vector3.Distance(cameraTransform.position, targetPosition) > 0.01f) // Seuil de 0.01f
        {
            cameraTransform.position = Vector3.SmoothDamp(
                cameraTransform.position,
                targetPosition,
                ref velocity,
                smoothSpeed
            );

            yield return null;
        }
    }
}
