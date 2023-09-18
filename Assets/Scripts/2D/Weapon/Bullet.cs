using UnityEngine;

public class Bullet : MonoBehaviour
{
    const int SPEED = 15;
    const int TTL_SECONDS = 10;

    public bool exists;

    public void Start()
    {
        exists = true;
        Destroy(gameObject, TTL_SECONDS);
    }

    public void AddForce(Vector2 direction)
    {
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.AddForce(
            new Vector3(SPEED * direction.x, SPEED * direction.y, 0),
            ForceMode.Impulse
        );
    }
}
