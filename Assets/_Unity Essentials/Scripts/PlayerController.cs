using UnityEngine;

/// <summary>
/// Controls player movement and rotation
/// </summary>
public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Set player's movement speed
    /// </summary>
    public float speed = 5f;

    /// <summary>
    /// Set player's rotation
    /// </summary>
    public float rotationSpeed = 120.0f;

    /// <summary>
    /// Set player's jump force
    /// </summary>
    public float jumpForce = 3.0f;

    /// <summary>
    /// Reference to player's Rigidbody
    /// </summary>
    private Rigidbody rb;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //Access player's Rigidbody
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
    }

    /// <summary>
    /// Handle physics-based movement and rotation
    /// </summary>
    private void FixedUpdate()
    {
        //Move player based on vertical input
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * moveVertical * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        //Rotate player based on horizontal input
        float turn = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
