using UnityEngine;

public class MovingPlatform : Platform
{
    [SerializeField] float speed = 2f; 
    [SerializeField] float range = 2f; 

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.position = startPosition + new Vector3(Mathf.Sin(Time.time * speed) * range, 0, 0);
    }
}
