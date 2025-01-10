using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Update()
    {
        float tilt = -Input.acceleration.x;
        Debug.Log(tilt);
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

}
