using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Controller : MonoBehaviour
{
    [Tooltip ("Character's movement force")]
    public float characterForce = 10.0f;
    [Tooltip ("First person camera sensitivity")]
    public float mouseSensitivity = 5.0f;
    [Tooltip ("The higher the smoothing, the 'looser' the camera feels")]
    public float mouseSmoothing = 2.0f;
    [Tooltip ("Maximum angle the camera can pitch downwards, in degrees")]
    [Range(0, 90)]
    public float pitchMinimum = 60;
    [Tooltip("Maximum angle the camera can pitch upwards, in degrees")]
    [Range(0, 90)]
    public float pitchMaximum = 60;

    Vector2 mouse_look;
    Vector2 smoothV;

    GameObject character_GO;

	void Start ()
    {
        // Locks and hides the cursor inside the game window
        Cursor.lockState = CursorLockMode.Locked;

        character_GO = transform.root.gameObject;
	}
	
	void Update ()
    {
        // Character movement calculation
        float forward_force = Input.GetAxis("Vertical") * characterForce;
        float strafe_force = Input.GetAxis("Horizontal") * characterForce;

        if (forward_force != 0 || strafe_force != 0)
        {
            Rigidbody rb_object = character_GO.GetComponent<Rigidbody>();
            Vector3 totalForce = Vector3.zero;

            totalForce += forward_force * character_GO.transform.forward;
            totalForce += strafe_force * character_GO.transform.right;
            totalForce *= Time.deltaTime;
            // Set y-velocity to its current, so that it remains unchanged
            totalForce.y = rb_object.velocity.y;
            // Applying character movement
            rb_object.velocity = totalForce;
        }

        // Camera panning calculation
        Vector2 delta_mouse = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        delta_mouse = Vector2.Scale(delta_mouse, new Vector2(mouseSensitivity * mouseSmoothing, mouseSensitivity * mouseSmoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, delta_mouse.x, 1f / mouseSmoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, delta_mouse.y, 1f / mouseSmoothing);
        mouse_look += smoothV;

        // Clamps the cameras y-axis panning to avoid neck snapping
        mouse_look.y = Mathf.Clamp(mouse_look.y, -pitchMinimum, pitchMaximum);

        // Apply camera movement
        transform.localRotation = Quaternion.AngleAxis(-mouse_look.y, Vector3.right);
        character_GO.transform.localRotation = Quaternion.AngleAxis(mouse_look.x, character_GO.transform.up);

        // Unlocks and unhides the cursor when "Escape" is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;
	}
}
