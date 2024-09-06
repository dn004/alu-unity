using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    public Vector3 offset = new Vector3(0f, 2.5f, -6.25f);
    public float mouseSensitivity = 100f;
    private float rotationX = 0f;

    private bool isInverted = false;

    void Start()
    {
        // Load the saved preference when the game starts
        isInverted = PlayerPrefs.GetInt("InvertY", 0) == 1;

        // Subscribe to the event from OptionsMenu
        OptionsMenu.OnInvertYChanged += UpdateInvertYSetting;
    }

    void Update()
    {
        // Get mouse input
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Adjust Y-axis based on the current setting
        if (isInverted)
        {
            mouseY = -mouseY;
        }

        // Apply Y-axis rotation to the camera
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Clamp to avoid over-rotation

        // Apply the Y-axis rotation only (no change to X-axis)
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        // Keep the camera at the player's position with the specified offset
        transform.position = Player.transform.position + offset;
    }

    // Method to update inversion dynamically (subscriber method)
    private void UpdateInvertYSetting(bool isInverted)
    {
        this.isInverted = isInverted;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the event when the object is destroyed
        OptionsMenu.OnInvertYChanged -= UpdateInvertYSetting;
    }
}
