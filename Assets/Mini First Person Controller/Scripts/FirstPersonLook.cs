using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField] Transform character;
    public float sensitivity = 2;
    public float smoothing = 1.5f;

    [Header("Damage Tilt Settings")]
    public float maxTiltAngle = 30f;
    private float currentTiltAngle = 0f; 
    private bool isTilted = false; 

    private Vector2 velocity;
    private Vector2 frameVelocity;

    void Reset()
    {
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
        frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
        velocity += frameVelocity;
        velocity.y = Mathf.Clamp(velocity.y, -90, 90);

        Quaternion baseRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
        character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);

        //if (isTilted)
        //{
        //    currentTiltAngle = Mathf.Lerp(currentTiltAngle, maxTiltAngle, Time.deltaTime * 10f);
        //}
        //else
        //{
        //    currentTiltAngle = Mathf.Lerp(currentTiltAngle, 0f, Time.deltaTime * 10f);
        //}

        Quaternion tiltRotation = Quaternion.Euler(0, 0, currentTiltAngle);
        transform.localRotation = baseRotation * tiltRotation;

        if (Input.GetKeyDown(KeyCode.H))
        {
            ToggleTilt();
        }
    }

    public void TiltCamera(float tiltAngle, float time)
    {
        currentTiltAngle = Mathf.Lerp(currentTiltAngle, tiltAngle, Time.deltaTime * time);
    }

    private void ToggleTilt()
    {
        isTilted = !isTilted;
    }
}




