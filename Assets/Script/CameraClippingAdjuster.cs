using UnityEngine;

public class CameraClippingAdjuster : MonoBehaviour
{
    public float newNearClipPlane = 0.1f; 

    void Start()
    {
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            mainCamera.nearClipPlane = newNearClipPlane;
            mainCamera.ResetProjectionMatrix(); 
            Debug.Log("Near Clip Plane: " + mainCamera.nearClipPlane);
        }
    }
}
