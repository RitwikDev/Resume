using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded { get; private set; }

    public void Start()
    {
        isGrounded = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (Tags.GROUND.Equals(other.tag))
        {
            isGrounded = true;
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
