using UnityEngine;

public class MovingPlatform : Platform
{
    [SerializeField] float speed = 2f; 
    [SerializeField] float range = 2f; 

    private Vector3 initialPos;
    private Vector3 startPosition;
    private Camera sceneCamera;
    void Start()
    {
        sceneCamera = Camera.main;
        initialPos = transform.position;
        initialPos.x = sceneCamera.transform.position.x;
        //transform.position = initialPos;
        startPosition = transform.position;
    }

    void Update()
    {
        transform.position = startPosition + new Vector3(Mathf.Sin(Time.time * speed) * range, 0, 0);
        Vector3 clampedPosition = transform.position;

        float platformHalfWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2f;
        float cameraHalfWidth = sceneCamera.orthographicSize * sceneCamera.aspect;

        float minX = sceneCamera.transform.position.x - cameraHalfWidth + platformHalfWidth;
        float maxX = sceneCamera.transform.position.x + cameraHalfWidth - platformHalfWidth;

        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        transform.position = clampedPosition;
    }
}
