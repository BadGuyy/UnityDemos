using UnityEngine;

public class BallControll : MonoBehaviour
{
    [Header("Ball1 Settings")]
    [Range(0.1f, 10f)]
    public float speed = 10f;
    [Header("Ball2 Settings")]
    [Range(0.1f, 10f)]
    public float force = 10f;

    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.linearVelocity = Vector3.left * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * force);
        }
    }
}
