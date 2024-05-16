using UnityEngine;
using Oculus.Platform;
using Oculus.Platform.Models;

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
        // Get the right analog stick input
        Vector2 rightStickInput = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);

        // Calculate the movement direction relative to the camera's facing direction
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Ensure the Y components of the direction vectors are zero
        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        // Calculate the desired movement direction
        Vector3 desiredMoveDirection = (forward * rightStickInput.y + right * rightStickInput.x) * speed * Time.deltaTime;

        // Apply the movement, but keep the Y position fixed
        transform.position = new Vector3(transform.position.x + desiredMoveDirection.x, fixedY, transform.position.z + desiredMoveDirection.z);
    }
}