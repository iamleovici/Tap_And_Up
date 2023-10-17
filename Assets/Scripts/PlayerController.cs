using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject playPanel;
    public LayerMask Ground;
    public Transform groundCheck;
    public PlatformController platformController;
    private int direction;
    public float jumpForce = 5f;
    public float fallForce = 5f;
    
    private void Update()
    {
        if (rb != null)
        {
            direction = platformController.SideOfPlatform < 0 ? 1 : -1;
            if (!IsGrounded())
            {
                rb.AddForce(Vector3.down);
            }
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (rb != null)
        {

            if (!playPanel.activeSelf)
            {
                if (context.performed && IsGrounded())
                    rb.AddForce(Vector3.up * jumpForce / 2 + Vector3.right * jumpForce * direction, ForceMode.Impulse);
                if (context.canceled && !IsGrounded())
                {
                    rb.velocity = new Vector3(0f, -fallForce, 0f);
                }
            }
        }

    }
    public bool IsGrounded()
    {
        if (groundCheck != null)
            return Physics.OverlapBox(groundCheck.position, groundCheck.transform.lossyScale, groundCheck.rotation, Ground).Length > 0;
        else
            return false;
    }
}
