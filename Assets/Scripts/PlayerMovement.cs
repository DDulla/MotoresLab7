using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 moveInput;
    public Rigidbody rb;

    [SerializeField] private AudioSource footstepSource;

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y) * moveSpeed;
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        HandleFootstepAudio();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void HandleFootstepAudio()
    {
        bool isMoving = rb.velocity.magnitude > 0.1f;

        if (isMoving && !footstepSource.isPlaying) 
        {
            footstepSource.loop = true;
            footstepSource.Play();
        }
        else if (!isMoving && footstepSource.isPlaying) 
        {
            footstepSource.Stop();
        }
    }
}