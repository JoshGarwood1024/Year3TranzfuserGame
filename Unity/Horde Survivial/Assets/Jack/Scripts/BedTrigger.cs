using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BedTrigger : MonoBehaviour
{
    public string sceneToLoad;
    private bool inTrigger = false;

    public Camera mainCamera;   // Reference to the main camera.
    public Transform target;    // Reference to the object you want to zoom in on.
    public float zoomAmount = 2.0f;  // Adjust this value for the zoom level.
    public float zoomDuration = 1.0f;  // Duration of the zoom effect in seconds.

    private Camera originalCamera;  // Store the original camera settings
    private float initialCameraSize;
    private Vector3 initialCameraPosition;
    private float zoomStartTime;
    private bool isZooming = false;

    private void Start()
    {
        originalCamera = mainCamera;  // Store the original camera settings.
        initialCameraSize = mainCamera.orthographicSize;
        initialCameraPosition = mainCamera.transform.position;
    }

    void Update()
    {
        if (isZooming)
        {
            float timeSinceStart = Time.time - zoomStartTime;
            if (timeSinceStart < zoomDuration)
            {
                float t = timeSinceStart / zoomDuration;
                mainCamera.orthographicSize = Mathf.Lerp(initialCameraSize, initialCameraSize / zoomAmount, t);
                mainCamera.transform.position = Vector3.Lerp(initialCameraPosition, new Vector3(target.position.x, target.position.y, mainCamera.transform.position.z), t);
            }
            else
            {
                mainCamera.orthographicSize = initialCameraSize / zoomAmount;
                mainCamera.transform.position = new Vector3(target.position.x, target.position.y, mainCamera.transform.position.z);
                isZooming = false;
                SceneManager.LoadScene(1);
            }
        }

        if (inTrigger && Input.GetKeyDown(KeyCode.E) && !isZooming)
        {
            if (!isZooming && target != null && mainCamera != null)
            {
                isZooming = true;
                zoomStartTime = Time.time;
            }           
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = false;
        }
    }
}
