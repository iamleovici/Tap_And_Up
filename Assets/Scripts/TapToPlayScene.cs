using UnityEngine;

public class TapToPlayScene : MonoBehaviour
{
    public GameObject cameraTarget;
    public GameObject playPanel;

    private float speed = 2f;

    private void Update()
    {
        if (!playPanel.activeSelf)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, cameraTarget.transform.position, speed * Time.deltaTime);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, cameraTarget.transform.rotation, speed * Time.deltaTime);
        }
    }
}
