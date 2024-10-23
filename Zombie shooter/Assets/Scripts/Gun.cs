using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrafab;
    public Transform bulletSpawnPoint;
    public int Bullet;
    public Text bulletText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletText.text = Bullet.ToString();

        ShootBullet();
    }

    void ShootBullet()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if ( Bullet > 0 )
            {
                GameObject newBullet;
                newBullet = Instantiate(bulletPrafab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                GameObject.Destroy(newBullet, 5);

                Bullet -= 1;
            }
        }
    }

    public void GiveBullet()
    {
        Bullet += 20;
    }
}
