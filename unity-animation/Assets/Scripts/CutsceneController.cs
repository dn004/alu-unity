using System.Collections;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public GameObject TimerObject;
    public GameObject PlayerObject;
    public GameObject CutSceneCamera;
    public float TimeToShow = 4f;

    private PlayerController playerController;

    private void Awake()
    {
        Debug.Log("CutsceneController Awake() called");

        // Check if these objects are being disabled properly
        TimerObject.SetActive(false);
        Debug.Log("TimerObject disabled");

        playerController = PlayerObject.GetComponent<PlayerController>();
        playerController.enabled = false;
        Debug.Log("PlayerController disabled");

        CutSceneCamera.SetActive(true);
        Debug.Log("CutSceneCamera activated");
    }

    private void Start()
    {
        Debug.Log("CutsceneController Start() called");
        StartCoroutine(FollowUp());
    }

    IEnumerator FollowUp()
    {
        yield return new WaitForSeconds(TimeToShow);

        TimerObject.SetActive(true);
        Debug.Log("TimerObject enabled");

        CutSceneCamera.SetActive(false);
        Debug.Log("CutSceneCamera deactivated");

        playerController.enabled = true;
        Debug.Log("PlayerController enabled");
    }
}
