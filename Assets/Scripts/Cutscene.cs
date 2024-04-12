using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public CinemachineVirtualCamera[] cameras;
    private int cameraIndex = 0;

    void Start()
    {
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        yield return new WaitForSeconds(2f);

        cameras[cameraIndex + 1].gameObject.SetActive(true);
        cameras[cameraIndex].gameObject.SetActive(false);

        cameraIndex++;

        if (cameraIndex >= cameras.Length - 1)
        {
            this.enabled = false;
            StopCoroutine(Transition());
        }

        StartCoroutine(Transition());

    }
}
