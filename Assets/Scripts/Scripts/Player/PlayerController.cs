using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 moveDir;
    [SerializeField]
    private Rigidbody _rb;
    [SerializeField]
    private Transform movePivot;
    [SerializeField]
    private CameraController controller;
    public float speed = 5.0f;

    private void Start()
    {
        controller = GetComponent<CameraController>();
    }

    private void Update()
    {
        moveDir = (movePivot.forward * Input.GetAxis("Vertical") +
            movePivot.right * Input.GetAxis("Horizontal")) * speed;
        Debug.Log(moveDir);
        _rb.linearVelocity = new Vector3(moveDir.x, _rb.linearVelocity.y, moveDir.z);
        movePivot.position = GameManager.Instance.player.transform.position;
        Jump();
        PivotRotation();
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(0, 10, 0);
        }
    }
    
    private void PivotRotation()
    {
        movePivot.eulerAngles = new Vector3(0f, controller.GetRotation(), 0f);
    }
}
