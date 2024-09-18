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

        TimerObject.SetActive(false);
        playerController = PlayerObject.GetComponent<PlayerController>();
        playerController.enabled = false;

        CutSceneCamera.SetActive(true);
    }

    private void Start()
    {
        StartCoroutine(FollowUp());
    }

    IEnumerator FollowUp()
    {
        yield return new WaitForSeconds(TimeToShow);

        TimerObject.SetActive(true);
        CutSceneCamera.SetActive(false);
        playerController.enabled = true;
    }
}
