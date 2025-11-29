using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public VirtualJoystick joystick; // Drag dari Inspector, untuk HP

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 moveInput = Vector2.zero;

        // 1. Input dari keyboard (WASD / Arrow Keys) - prioritas untuk PC/laptop
        float horizontal = Input.GetAxisRaw("Horizontal"); // A/D / Left/Right
        float vertical = Input.GetAxisRaw("Vertical");     // W/S / Up/Down
        moveInput = new Vector2(horizontal, vertical);

        // 2. Jika keyboard idle dan joystick tersedia, pakai joystick
        if (moveInput.magnitude == 0 && joystick != null)
        {
            moveInput = joystick.input;
        }

        // Normalisasi supaya diagonal tidak lebih cepat
        if (moveInput.magnitude > 1)
            moveInput.Normalize();

        // Gerakkan Rigidbody2D
        rb.velocity = moveInput * moveSpeed;
    }
}
