using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CameraFollow : MonoBehaviour
{
    public Transform DoddlePostion;

    private void LateUpdate()
    {
        if(DoddlePostion.position.y > transform.position.y)
        {
           Vector3 newPosition = new Vector3 (transform.position.x, DoddlePostion.position.y, transform.position.z);
           transform.position = newPosition;
        }
    }

}
