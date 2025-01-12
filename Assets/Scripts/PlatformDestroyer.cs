using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < Camera.main.transform.position.y - 10f)
        {
            Destroy(gameObject);
        }
    }
}
