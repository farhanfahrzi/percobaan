using UnityEngine;

public class TongSampahGM2 : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 offset;
    public float maxX = 8.5f;
    public float minX = -8.5f;

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            float rawX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x + offset.x;
            float clampedX = Mathf.Clamp(rawX, minX, maxX);
            Vector2 newPosition = new Vector2(clampedX, transform.position.y);

            transform.position = newPosition;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }
}
