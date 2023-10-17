using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    public GameObject trigger;
    public GameObject deathTrigger;


    private void OnEnable()
    {
        PlatformController.onTouch += PlayerOnPlatform;
    }
    private void OnDisable()
    {
       PlatformController.onTouch -= PlayerOnPlatform;

    }

    public void PlayerOnPlatform()
    {
        Destroy(trigger);
        Destroy(deathTrigger);
    }
}
