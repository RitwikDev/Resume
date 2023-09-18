using UnityEngine;

public class PGun : MonoBehaviour
{
    public enum GunType
    {
        None,
        HTML,
        CSharp,
        Java,
        Php,
    }

    public GunType currentGun;

    public void Start()
    {
        currentGun = GunType.HTML;
    }
}
