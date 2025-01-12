using UnityEngine;
using UnityEngine.UI;

public class ScrollingImage : MonoBehaviour
{
    [SerializeField] RawImage img;
    [SerializeField] float x;
    [SerializeField] float y;

    void Update()
    {
        img.uvRect =new Rect(img.uvRect.position + new Vector2(x, y) * Time.deltaTime,img.uvRect.size);
    }
}
