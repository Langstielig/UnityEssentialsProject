using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    private Animator doorAnimator;
    
    /// <summary>
    /// Get the Animator component attached to the same GameObject as this script
    /// </summary>
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
    }

    /// <summary>
    /// Trigger the Door_Open animation
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(doorAnimator != null)
            {
                
                doorAnimator.SetTrigger("Door_Open");
            }
        }
    }
}
