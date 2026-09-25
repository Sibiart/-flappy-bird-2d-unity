using UnityEngine;

public class pipescript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadpipezone = -45;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Cleanup check stays framerate-based; it's just a despawn bound, not physics-critical
        if (transform.position.x < deadpipezone)
        {
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        // Move via the Rigidbody2D so physics (and trigger detection) stays in sync every step,
        // instead of nudging transform.position directly which Kinematic/Static bodies don't
        // reliably sync to the physics world in time for fast-moving trigger checks.
        Vector2 newPos = rb.position + Vector2.left * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPos);
    }
}
