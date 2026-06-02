using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public Transform cameraPivot;
    private Vector3 cameraOffset = new Vector3(0, 3, -10);
    private Vector3 playerPos;

    //Look
    private float rotationClamp = 85f;
    private float xRot = 0f;
    private float yRot = 0f;
    private Vector2 lastMousePos = new Vector2(0,0);
    private Vector2 curMousePos;
    private Vector3 mouseDelta;
    public float mouseSensitive = 10;

    private void Start()
    {
       cameraPivot.rotation = Quaternion.identity;
    }

    private void Update()
    {
        cameraPivot.transform.position = GameManager.Instance.player.transform.position;

        curMousePos = Input.mousePosition;
        mouseDelta = new Vector3(curMousePos.x - lastMousePos.x, curMousePos.y - lastMousePos.y, 0);
        lastMousePos = curMousePos;
        xRot -= mouseDelta.y;
        yRot += mouseDelta.x;
        cameraPivot.eulerAngles = new Vector3(Mathf.Clamp(xRot, -rotationClamp, rotationClamp), yRot, 0f);
        //cameraPivot.rotation *= Quaternion.Euler(mouseDelta * mouseSensitive);
    }
    
    public float GetRotation()
    {
        return yRot;
    }
}