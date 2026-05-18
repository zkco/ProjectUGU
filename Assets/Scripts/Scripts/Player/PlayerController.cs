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
                              _rb.linearVelocity.y, //y valye
                              Input.GetAxis("Vertical")).normalized; //z value .normalized
        _rb.linearVelocity = moveDir * speed;
        Jump();
    }

    private void Jump()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            _rb.AddForce(0, 10, 0);
        }
    }
}
