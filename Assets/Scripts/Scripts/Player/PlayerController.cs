using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 moveDir;
    public float speed = 5.0f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        moveDir = new Vector3(Input.GetAxis("Horizontal"),  //x value
                              0, //y valye
                              Input.GetAxis("Vertical")).normalized; //z value .normalized
        _rb.linearVelocity = new Vector3(moveDir.x * speed, _rb.linearVelocity.y, moveDir.z * speed);
        Jump();
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(0, 10, 0);
        }
    }
}
