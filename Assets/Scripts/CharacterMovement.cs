using UnityEngine;
using Oculus.Platform;
using Oculus.Platform.Models;
using static OVRInput;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 3.0f;
    public Transform cameraTransform;
    private float fixedY;

    void Start()
    {
        // Store the initial Y position
        fixedY = transform.position.y;
    }

    void Update()
    {
        // Get the input from both analog sticks
        Vector2 rightStickInput = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);
        Vector2 leftStickInput = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);

        // Calculate the movement direction relative to the camera's facing direction for each stick
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Ensure the Y components of the direction vectors are zero
        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        // Calculate the desired movement direction for each stick
        Vector3 desiredMoveDirectionRight = (forward * rightStickInput.y + right * rightStickInput.x) * speed * Time.deltaTime;
        Vector3 desiredMoveDirectionLeft = (forward * leftStickInput.y + right * leftStickInput.x) * speed * Time.deltaTime;

        // Apply the movement for each stick, but keep the Y position fixed
        transform.position += new Vector3(desiredMoveDirectionRight.x, 0, desiredMoveDirectionRight.z);
        transform.position += new Vector3(desiredMoveDirectionLeft.x, 0, desiredMoveDirectionLeft.z);

        // Ensure the Y position remains fixed
        transform.position = new Vector3(transform.position.x, fixedY, transform.position.z);
    }
}