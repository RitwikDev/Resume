using UnityEngine;

public class Movement : AbstractMovement
{
    private float moveDirection;
    public float momentumFactor = 0;

    public void Update()
    {
        isGrounded = groundCheck.isGrounded;

        HandleMomentum();
        characterController.Move(velocity * Time.deltaTime);
    }

    public void FixedUpdate()
    {
        velocity.y = isGrounded && velocity.y < 0
            ? 0
            : velocity.y;

        if (!isGrounded)
        {
            ApplyGravity();
        }
    }

    public override void Move(float moveValue)
    {
        moveDirection = moveValue;
    }

    private void HandleMomentum()
    {
        if (moveDirection != 0)
        {
            momentumFactor = momentumFactor
                + (moveDirection * PlayerConstants.ACCELERATION * Time.deltaTime);

            momentumFactor = Mathf.Clamp(momentumFactor, -1, 1);
        }

        else
        {
            if (momentumFactor < 0.1f && momentumFactor > -0.1f)
            {
                momentumFactor = 0;
            }

            else
            {
                float timeFactor = isGrounded ? Time.deltaTime : Time.deltaTime / 3f;

                if (momentumFactor > 0)
                {
                    momentumFactor = momentumFactor
                        - (PlayerConstants.ACCELERATION * timeFactor);
                }

                else
                {
                    momentumFactor = momentumFactor
                         + (PlayerConstants.ACCELERATION * timeFactor);
                }
            }
        }

        velocity = new Vector3(momentumFactor * PlayerConstants.SPEED, velocity.y, 0);
    }
}
