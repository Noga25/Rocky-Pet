using UnityEngine;

public class SoapScript : MonoBehaviour
{
    private Camera MainCamera { get; set; }
    private Vector3 TouchPosition { get; set; }
    private bool IsDragging { get; set; }

    private float Posx { get; set; }
    private float Posy { get; set; }

    void Start()
    {
        MainCamera = Camera.main;

        Posx = transform.position.x;
        Posy = transform.position.y;
    }

    void Update()
    {
        DruggingObject();
    }

    private void DruggingObject()
    {
        // Check if there is at least one touch on screen
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Convert touch position to world position
            TouchPosition = MainCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f));

            if (touch.phase == TouchPhase.Began)
            {
                // Optional: check if the finger touches the soap
                Collider2D hit = Physics2D.OverlapPoint(TouchPosition);
                if (hit != null && hit.gameObject == gameObject)
                {
                    IsDragging = true;
                }
            }
            else if (touch.phase == TouchPhase.Moved && IsDragging)
            {
                // Move soap with finger
                transform.position = new Vector3(TouchPosition.x, TouchPosition.y, transform.position.z);
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                // Stop dragging
                IsDragging = false;

                transform.position = new Vector3(Posx, Posy, 0);
            }
        }
    }
}
