using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb;
    private Vector3 moveDir;
    public Transform movePivot;
    public float speed = 5.0f;

    private void Update()
    {
        movePivot.position = transform.position;
        moveDir = movePivot.forward * Input.GetAxis("Vertical") * speed 
            + movePivot.right * Input.GetAxis("Horizontal") * speed;

        _rb.linearVelocity = new Vector3(moveDir.x, _rb.linearVelocity.y, moveDir.z);

        Jump();
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(new Vector3(0,10f,0), ForceMode.Impulse);
        }
    }
}
