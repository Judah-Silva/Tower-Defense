using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 2f;
    public CinemachineVirtualCamera camera;

    public float scrollSpeed = 5f;

    public float minY = 10f;
    public float maxY = 80f;


    // Update is called once per frame
    void Update()
    {
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetKey(KeyCode.Mouse2))
        {
            float xMove = Input.GetAxis("Mouse X") * rotationSpeed;// * Time.deltaTime;
            // float yMove = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            
            camera.transform.RotateAround(camera.LookAt.position, Vector3.up, xMove);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        
        transform.position = pos;
    }
}
