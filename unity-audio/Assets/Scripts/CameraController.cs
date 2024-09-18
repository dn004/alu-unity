using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    public Vector3 offset = new Vector3(0f, 2.5f, -6.25f);
    public float mouseSensitivity = 100f;
    private float rotationX = 0f;

    public bool isInverted = false;

    void Start()
    {
        isInverted = PlayerPrefs.GetInt("InvertY", 0) == 1;

        OptionsMenu.OnInvertYChanged += UpdateInvertYSetting;
    }

    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        if (isInverted)
        {
            mouseY = -mouseY;
        }

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        transform.position = Player.transform.position + offset;
    }

    private void UpdateInvertYSetting(bool isInverted)
    {
        this.isInverted = isInverted;
    }

    private void OnDestroy()
    {
        OptionsMenu.OnInvertYChanged -= UpdateInvertYSetting;
    }
}
