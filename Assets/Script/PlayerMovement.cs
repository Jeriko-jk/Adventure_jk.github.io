using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public VirtualJoystick joystick; // drag dari inspector

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (joystick != null)
        {
            // Ambil input dari joystick
            Vector2 moveInput = joystick.input;

            // Normalisasi supaya diagonal tidak lebih cepat
            if (moveInput.magnitude > 1)
                moveInput.Normalize();

            // Gerakkan Rigidbody2D
            rb.velocity = moveInput * moveSpeed;
        }
    }
}
