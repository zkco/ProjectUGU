using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerController _controller;
    [SerializeField]
    private CameraController _camController;
    private void Update()
    {
        _controller.movePivot.rotation = Quaternion.Euler(0, _camController.GetRotation(), 0);
    }
}
