using UnityEngine;

public class PFire : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private GameObject firePoint;

    private Character player;

    public void Start()
    {
        player = GetComponent<Character>();
    }

    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);

        switch(player.currentLookDirection)
        {
            case Character.LookDirection.Up:
                bullet.GetComponent<Bullet>().AddForce(new Vector2(0, 1));
                break;

            case Character.LookDirection.RightUp:
                bullet.GetComponent<Bullet>().AddForce(new Vector2(1, 1));
                break;

            case Character.LookDirection.Right:
                bullet.GetComponent<Bullet>().AddForce(new Vector2(1, 0));
                break;

            case Character.LookDirection.RightDown:
                bullet.GetComponent<Bullet>().AddForce(new Vector2(1, -1));
                break;

            case Character.LookDirection.Down:
                if (player.isJumping)
                {
                    bullet.GetComponent<Bullet>().AddForce(new Vector2(0, -1));
                }

                else
                {
                    if(player.horizontalDirection == Character.LookDirection.Right)
                    {
                        bullet.GetComponent<Bullet>().AddForce(new Vector2(1, 0));
                    }

                    else
                    {
                        bullet.GetComponent<Bullet>().AddForce(new Vector2(-1, 0));
                    }
                }
                break;

            case Character.LookDirection.LeftDown:
                bullet.GetComponent<Bullet>().AddForce(new Vector2(-1, -1));
                break;

            case Character.LookDirection.Left:
                bullet.GetComponent<Bullet>().AddForce(new Vector2(-1, 0));
                break;

            default:
                bullet.GetComponent<Bullet>().AddForce(new Vector2(-1, 1));
                break;
        }
    }
}
