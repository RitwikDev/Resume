using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded { get; private set; }

    private Character character;

    public void Start()
    {
        isGrounded = false;
        character = GetComponentInParent<Character>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (Tags.GROUND.Equals(other.tag))
        {
            isGrounded = true;
            character.isJumping = false;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (Tags.GROUND.Equals(other.tag))
        {
            isGrounded = false;
        }
    }
}
