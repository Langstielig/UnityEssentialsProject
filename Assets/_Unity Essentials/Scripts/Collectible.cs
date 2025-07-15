using UnityEngine;
using System;

public class Collectible : MonoBehaviour
{
    private AudioSource audioSource;
    private MeshRenderer meshRenderer;
    private BoxCollider boxCollider;

    public float rotationSpeed;
    public GameObject onCollectEffect;
    public GameObject onWinEffect;
    public AudioClip collectSound;
    public AudioClip winSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        transform.Rotate(0f, rotationSpeed, 0f);
    }

    /// <summary>
    /// Destroy the collectible
    /// </summary>
    /// <param name="other">player</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int totalCollectibles = 0;
            float delay = 0f;

            // Check and count objects of type Collectible
            Type collectibleType = Type.GetType("Collectible");
            if (collectibleType != null)
            {
                totalCollectibles += UnityEngine.Object.FindObjectsOfType(collectibleType).Length;
            }

            bool isLastCollectible = totalCollectibles == 1;

            if (!isLastCollectible)
            {
                if(audioSource != null && collectSound != null)
                {
                    audioSource.PlayOneShot(collectSound);
                    delay = 0.2f;
                }
                Instantiate(onCollectEffect, transform.position, transform.rotation);
            }
            else
            {
                if(audioSource != null && winSound != null)
                {
                    audioSource.PlayOneShot(winSound);
                    delay = 2f;
                }
                Quaternion rotation = Quaternion.AngleAxis(90f, Vector3.left);
                Instantiate(onWinEffect, transform.position, rotation);
            }

            meshRenderer.enabled = false;
            boxCollider.enabled = false;

            Destroy(gameObject, delay);
        }
    }
}