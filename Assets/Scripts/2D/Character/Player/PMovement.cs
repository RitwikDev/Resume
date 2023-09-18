using UnityEngine;

public class PMovement : AbstractMovement
{
    private float moveDirection;
    private float momentumFactor = 0;

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

    public void Move(float moveValue)
    {
        moveDirection = moveValue > 0 ? 1 : (moveValue < 0 ? -1 : 0);
        RotatePlayer();
    }

    private void RotatePlayer()
    {
        if (moveDirection == 1)
        {
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }

        else if (moveDirection == -1)
        {
            transform.rotation = Quaternion.Euler(Vector3.down * 180);
        }
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
