using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    public InputAction gameplay2DActions;

    private Character character;
    private PMovement movement;
    private PFire fire;

    public void Start()
    {
        character = GetComponent<Character>();
        movement = GetComponent<PMovement>();
        fire = GetComponent<PFire>();
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
            Vector2 input = context.ReadValue<Vector2>();

            movement.Move(input.x);
            character.SetLookDirection(input);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            movement.Jump();
        }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            fire.Fire();
        }
    }
}
