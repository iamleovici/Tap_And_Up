using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerBody;
    private Vector3 targetPosition;
    private Vector3 newPosition;
    public float speed = 0.015f;
    public float offset = -3f;


    private void LateUpdate()
    {
        UpdatePosition();
    }
    public void UpdatePosition()
    {
        if (playerBody != null)
        {
            targetPosition = new Vector3(0f, playerBody.position.y + offset, -10f);
            newPosition = Vector3.Lerp(transform.position, targetPosition, speed);
            transform.position = newPosition;

        }
    }
}
