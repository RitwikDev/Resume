using UnityEngine;

public class Character : MonoBehaviour
{
    public enum LookDirection
    {
        Up,
        LeftUp,
        Left,
        LeftDown,
        Down,
        RightDown,
        Right,
        RightUp,
    }

    public LookDirection currentLookDirection;
    public LookDirection horizontalDirection;
    public bool isJumping;


    public void Start()
    {
        currentLookDirection = LookDirection.Right;
        horizontalDirection = LookDirection.Right;
    }

    public void SetLookDirection(Vector2 input)
    {
        float x = input.x;
        float y = input.y;

        if (x > 0)
        {
            horizontalDirection = LookDirection.Right;

            if (y > 0)
            {
                currentLookDirection = LookDirection.RightUp;
            }

            else if (y < 0)
            {
                currentLookDirection = LookDirection.RightDown;
            }

            else
            {
                currentLookDirection = LookDirection.Right;
            }
        }

        else if (x < 0)
        {
            horizontalDirection = LookDirection.Left;

            if (y > 0)
            {
                currentLookDirection = LookDirection.LeftUp;
            }

            else if (y < 0)
            {
                currentLookDirection = LookDirection.LeftDown;
            }

            else
            {
                currentLookDirection = LookDirection.Left;
            }
        }

        else
        {
            if (y > 0)
            {
                currentLookDirection = LookDirection.Up;
            }

            else if (y < 0)
            {
                currentLookDirection = LookDirection.Down;
            }

            else
            {
                currentLookDirection = horizontalDirection;
            }
        }
    }
}
