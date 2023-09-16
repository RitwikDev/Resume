using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    public InputAction gameplay2DActions;

    private Movement movement;

    public void Start()
    {
        movement = gameObject.GetComponent<Movement>();
    }

    public void OnEnable()
    {
        gameplay2DActions.Enable();
    }

    public void OnDisable()
    {
        gameplay2DActions.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
        {
            movement.Move(context.ReadValue<float>());
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            movement.Jump();
        }
    }
}
