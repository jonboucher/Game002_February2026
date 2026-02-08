using NUnit.Framework;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    int maxOnScreenBullets = 4;
    [HideInInspector] public int onScreenBullets = 0;

    public void Shoot(float direction)
    {
        if (onScreenBullets < maxOnScreenBullets)
        {
            GameObject firedBulletRef = Instantiate(bullet, transform.position, Quaternion.identity);
            Bullet firedBullet = firedBulletRef.GetComponent<Bullet>();
            firedBullet.firedFrom = this;
            firedBullet.speed = firedBullet.speed * direction;
            onScreenBullets++;
        }
    }
}
