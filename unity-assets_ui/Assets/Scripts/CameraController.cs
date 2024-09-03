using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    public Vector3 offset = new Vector3(0f, 2.5f, -6.25f);
   
    void Update()
    {
        transform.position = Player.transform.position + offset;
    }

}
