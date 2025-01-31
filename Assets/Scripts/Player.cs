using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public FixedJoystick moveJoystick;
    public FixedJoystick aimJoystick;
    public Rigidbody2D rigidBody;
    public SpriteRenderer playerSprite => GetComponent<SpriteRenderer>();
    public Bullet bulletPrefab;
    public GameObject shooter;
    public ColorManager colorManager = new ColorManager();
    public float moveSpeed = 2;
    private bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Keyboard controls
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0.005f, 0);
        } 
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -0.005f, 0);
        } 
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-0.005f, 0, 0);
        } 
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0.005f, 0, 0);
        }
        Move();
        Aim();

        shooter.transform.rotation = transform.rotation;
        shooter.transform.position = transform.position + transform.up * 0.4f;
    }

    public void Move()
    {
        Vector2 moveVector = new Vector2(moveJoystick.Horizontal, moveJoystick.Vertical);
        if (moveVector.magnitude >= .1f)
        {
            rigidBody.velocity = moveVector * moveSpeed;
            float angle = Mathf.Atan2(moveVector.y, moveVector.x) * Mathf.Rad2Deg;
        }
        else
        {
            rigidBody.velocity = Vector2.zero;
        }
    }

    public void Aim()
    {
        float horizontalInput = aimJoystick.Horizontal;
        float verticalInput = aimJoystick.Vertical;

        shooter.SetActive(horizontalInput != 0 || verticalInput != 0);

        float angle = Mathf.Atan2(horizontalInput, verticalInput) * Mathf.Rad2Deg;
        if (angle < 0) angle += 360;
        angle = Mathf.Round(angle / 45) * 45;

        transform.rotation = Quaternion.Euler(0, 0, -angle);

        // Shooting
        if (canShoot && (horizontalInput != 0 || verticalInput != 0))
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        canShoot = false;
        Bullet bullet = Instantiate(bulletPrefab, shooter.transform.position, shooter.transform.rotation);
        bullet.rigidBody.AddForce(shooter.transform.up * 20f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }
}
