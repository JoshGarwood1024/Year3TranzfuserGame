using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BedTrigger : MonoBehaviour
{
    public string sceneToLoad;
    private bool inTrigger = false;

    public Camera mainCamera;   
    public Transform target;    
    public float zoomAmount = 2.0f;  
    public float zoomDuration = 1.0f;

    public Image image;
    public float fadeDuration = 2.0f;
    private float currentAlpha = 0.0f;



    private Camera originalCamera;  
    private float initialCameraSize;
    private Vector3 initialCameraPosition;
    private float zoomStartTime;
    private bool isZooming = false;

    private void Start()
    {
        originalCamera = mainCamera;  
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
                image.gameObject.SetActive(true);
                    currentAlpha += Time.deltaTime / fadeDuration;
                    image.color = new Color(image.color.r, image.color.g, image.color.b, currentAlpha);
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
