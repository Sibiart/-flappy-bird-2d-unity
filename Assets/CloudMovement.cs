using UnityEngine;

/// <summary>
/// Lightweight, reusable horizontal cloud scroller for 2D mobile games.
/// Moves this object's transform left at a constant speed every frame and
/// recycles it back to the right edge of the camera view once it exits the
/// left side, instead of ever calling Instantiate/Destroy at runtime.
/// Attach directly to any cloud SpriteRenderer GameObject.
/// </summary>
public class CloudMovement : MonoBehaviour
{
    [Header("Movement")]
    [Tooltip("Horizontal speed in world units per second. The cloud always drifts left.")]
    public float speed = 1f;

    [Header("Recycle Bounds (world space X)")]
    [Tooltip("When the cloud's X position drops to or below this value, it is recycled to the right side.")]
    public float leftBound = -12f;
    [Tooltip("World X position the cloud is moved to when it is recycled.")]
    public float rightBound = 12f;

    [Header("Randomization On Recycle")]
    [Tooltip("If true, picks a new random Y position each time the cloud recycles, for visual variety.")]
    public bool randomizeYOnRecycle = true;
    public float minY = -1.5f;
    public float maxY = 3.5f;

    [Tooltip("If true, picks a new random speed each time the cloud recycles, so clouds don't move in lockstep.")]
    public bool randomizeSpeedOnRecycle = true;
    public float minSpeed = 0.6f;
    public float maxSpeed = 1.6f;

    void Update()
    {
        // Simple, cheap transform translation - no physics/rigidbody needed, ideal for mobile.
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x <= leftBound)
        {
            Recycle();
        }
    }

    /// <summary>
    /// Moves the cloud back to the right side of the screen instead of destroying/instantiating it.
    /// </summary>
    void Recycle()
    {
        Vector3 pos = transform.position;
        pos.x = rightBound;

        if (randomizeYOnRecycle)
        {
            pos.y = Random.Range(minY, maxY);
        }

        transform.position = pos;

        if (randomizeSpeedOnRecycle)
        {
            speed = Random.Range(minSpeed, maxSpeed);
        }
    }
}
