using System.Collections;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
        StartCoroutine(EnableSoundAfterDelay(1f));
    }

    IEnumerator EnableSoundAfterDelay(float delay)
    {
        audioSource.enabled = false;
        yield return new WaitForSeconds(delay);
        audioSource.enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(audioSource != null && audioSource.enabled)
        {
            audioSource.Play();
        }
    }
}
