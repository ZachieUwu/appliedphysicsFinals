using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 10f;
    private float accele = 10f;
    [SerializeField] private float jumpForce = 5f;

    Rigidbody rb;
    Vector3 dir;

    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        dir = new Vector3(
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical")
        );

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        Moving();
    }

    void Moving()
    {
        Vector3 target = dir.normalized * speed;
        Vector3 velocity = target - rb.linearVelocity;
        velocity.y = 0;

        rb.AddForce(velocity * accele, ForceMode.Acceleration);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}