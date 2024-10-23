using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if( other.CompareTag("Enemy") )
        {
            GameObject.Destroy(gameObject);

            Enemy hitEnemy;
            hitEnemy = other.GetComponent<Enemy>();
            hitEnemy.DoDamage();
        }
    }
}
