using UnityEngine;

public class Tramp : MonoBehaviour
{
    [SerializeField] float force = 20f;
    private Rigidbody rb;

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }
}
