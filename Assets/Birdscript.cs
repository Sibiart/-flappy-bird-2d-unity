using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Birdscript : MonoBehaviour
{
    public Rigidbody2D myrigidbody;
    public float flapstrength = 12;
    public LogicScript Logic;
    public bool birdisalive = true;

    [Header("Wings")]
    public SpriteRenderer wingRenderer;
    public SpriteRenderer wingRenderer2;
    public Sprite wingUpSprite;
    public Sprite wingDownSprite;
    public float flapRotationAngle = 35f;
    public float flapUpTime = 0.06f;
    public float flapDownTime = 0.09f;
    private Coroutine flapRoutine;
    private Quaternion wing1RestRotation;
    private Quaternion wing2RestRotation;

    [Header("Audio")]
    public AudioSource flapAudioSource;
    public AudioClip flapClip;

    [Header("Bounds")]
    public float boundsMargin = 0.6f;
    private Camera mainCam;

    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        Logic = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicScript>();
        mainCam = Camera.main;

        if (wingRenderer != null)
        {
            wing1RestRotation = wingRenderer.transform.localRotation;
            if (wingDownSprite != null) wingRenderer.sprite = wingDownSprite;
        }
        if (wingRenderer2 != null)
        {
            wing2RestRotation = wingRenderer2.transform.localRotation;
            if (wingDownSprite != null) wingRenderer2.sprite = wingDownSprite;
        }
    }

    void Update()
    {
        bool tapped = false;
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame) tapped = true;
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame) tapped = true;
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame) tapped = true;

        if (tapped && birdisalive)
        {
            myrigidbody.linearVelocity = Vector2.up * flapstrength;
            PlayFlapSound();
            AnimateWingFlap();
        }

        if (birdisalive)
        {
            CheckOutOfBounds();
        }
    }

    void PlayFlapSound()
    {
        if (flapAudioSource != null && flapClip != null)
        {
            flapAudioSource.PlayOneShot(flapClip);
        }
    }

    void AnimateWingFlap()
    {
        if (wingRenderer == null && wingRenderer2 == null) return;
        if (flapRoutine != null) StopCoroutine(flapRoutine);
        flapRoutine = StartCoroutine(FlapRoutine());
    }

    IEnumerator FlapRoutine()
    {
        // Swap to the up sprite if one is assigned (optional, works with or without it)
        if (wingUpSprite != null)
        {
            if (wingRenderer != null) wingRenderer.sprite = wingUpSprite;
            if (wingRenderer2 != null) wingRenderer2.sprite = wingUpSprite;
        }

        // Rotate wings up into the flap pose
        if (wingRenderer != null)
            wingRenderer.transform.localRotation = wing1RestRotation * Quaternion.Euler(0f, 0f, flapRotationAngle);
        if (wingRenderer2 != null)
            wingRenderer2.transform.localRotation = wing2RestRotation * Quaternion.Euler(0f, 0f, -flapRotationAngle);

        yield return new WaitForSeconds(flapUpTime);

        // Back to rest pose / down sprite
        if (wingDownSprite != null)
        {
            if (wingRenderer != null) wingRenderer.sprite = wingDownSprite;
            if (wingRenderer2 != null) wingRenderer2.sprite = wingDownSprite;
        }
        if (wingRenderer != null)
            wingRenderer.transform.localRotation = wing1RestRotation;
        if (wingRenderer2 != null)
            wingRenderer2.transform.localRotation = wing2RestRotation;

        yield return new WaitForSeconds(flapDownTime);
        flapRoutine = null;
    }

    void CheckOutOfBounds()
    {
        if (mainCam == null) return;
        float halfHeight = mainCam.orthographicSize + boundsMargin;
        float camY = mainCam.transform.position.y;
        if (transform.position.y > camY + halfHeight || transform.position.y < camY - halfHeight)
        {
            birdisalive = false;
            Debug.Log("Bird left display range -> Game Over");
            Logic.gameover();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit: " + collision.gameObject.name);
        birdisalive = false;
        Logic.gameover();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger with: " + collision.gameObject.name);
    }
}
