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

    void Update()
    {
        // Ambil input dari joystick
        Vector2 moveInput = joystick.input;
        rb.velocity = moveInput * moveSpeed;
    }
}
