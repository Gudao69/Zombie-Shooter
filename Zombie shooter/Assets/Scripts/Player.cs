using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public CharacterController cc;
    public Transform cameraTransform;
    public float moveSpeed;
    public Gun myGun;
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();   

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        PlayerLook();
    }

    void PlayerLook()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        transform.Rotate(0, x ,0 );
        cameraTransform.Rotate(-y,0,0);
    }

    void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveVector = new Vector3();
        moveVector.x = x;
        moveVector.z = z;

        // Change vector from global to local
        moveVector = transform.TransformDirection(moveVector);

        cc.SimpleMove(moveVector * moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if( other.CompareTag("BulletBox") )
        {
            GameObject.Destroy(other.gameObject);
            myGun.GiveBullet();
        }
    }

    public void RedcueHealth()
    {
        health -= 1;

        if(health < 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
