using System.Collections;
using Unity.Android.Gradle;
using UnityEngine;

public class SoapScript : MonoBehaviour
{
    [SerializeField] private GameObject BubbleOrFoam;

    private Camera MainCamera { get; set; }
    private Vector3 TouchPosition { get; set; }
    private bool IsDragging { get; set; }

    private float Posx { get; set; }
    private float Posy { get; set; }
    private float Posz { get; set; }

    private float BubblePosx { get; set; }
    private float BubblePosy { get; set; }
    private float BubblePosz { get; set; }

    void Start()
    {
        MainCamera = Camera.main;

        //Check the begging point of the soap
        Posx = transform.position.x;
        Posy = transform.position.y;
        Posz = transform.position.z;

        //Check the begging point of the bubble
        BubblePosx = BubbleOrFoam.transform.position.x;
        BubblePosy = BubbleOrFoam.transform.position.y;
        BubblePosz = BubbleOrFoam.transform.position.z;
    }

    void Update()
    {
        DruggingObject();
    }

    // Respensiable on the soap and bubble location and movment and the interaction
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
                // check if the finger touches the soap
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

                // show the bubble and make them go up
                BubbleOrFoam.SetActive(true);
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                // Stop dragging
                IsDragging = false;
                transform.position = new Vector3(Posx, Posy, Posz);

                //Stop bubbles
                BubbleOrFoam.SetActive(false);
                BubbleOrFoam.transform.position = new Vector3( BubblePosx, BubblePosy, BubblePosz);
            }
        }
    }
}
