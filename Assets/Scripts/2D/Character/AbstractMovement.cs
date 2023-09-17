using UnityEngine;

public abstract class AbstractMovement : MonoBehaviour
{
    protected CharacterController characterController;
    protected GroundCheck groundCheck;
    protected Vector3 velocity;
    protected bool isGrounded;

    private float factor = 1.5f;

    public void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        groundCheck = gameObject.GetComponentInChildren<GroundCheck>();
    }

    protected void ApplyGravity()
    {
        if(velocity.y > 0)  // if the character is taking off
        {
            factor = 1.5f;
        }

        else
        {
            factor = factor > 3f
                ? 3f
                : factor * 1.25f;
        }

        velocity.y = velocity.y + (CharacterConstants.GRAVITY * Time.fixedDeltaTime * factor);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            velocity.y = velocity.y + Mathf.Sqrt(CharacterConstants.JUMP_HEIGHT * -CharacterConstants.GRAVITY);
        }
    }

    public abstract void Move(float moveValue = 0);
}
