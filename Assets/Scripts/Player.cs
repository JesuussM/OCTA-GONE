using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
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
    public UIManager uiManager;
    private bool splitShotOnSnareUpgrade = false;
    private bool moveFasterOnBeatUpgrade = false;
    private bool isMovementBoostActive = false;

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
        shooter.transform.position = transform.position + transform.up * 0.38f;
    }

    public void Move()
    {
        Vector2 moveVector = new Vector2(moveJoystick.Horizontal, moveJoystick.Vertical);
        if (moveVector.magnitude >= .1f)
        {
            if (moveFasterOnBeatUpgrade && !isMovementBoostActive)
            {
                StartCoroutine(MovementBoost());
            }
            rigidBody.velocity = moveVector * moveSpeed;
            float angle = Mathf.Atan2(moveVector.y, moveVector.x) * Mathf.Rad2Deg;

            // ? Maybe add particles to trail behind 
            // ? (probably not until later)
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
        yield return new WaitForSeconds(1f); // ? Might need to adjust this
        canShoot = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "LeftShopCircle")
        {
            uiManager.upgradeSelected = true;
            UpgradePlayer("left");
        }
        else if (collision.gameObject.name == "RightShopCircle")
        {
            uiManager.upgradeSelected = true;
            UpgradePlayer("right");
        }
    }

    private void UpgradePlayer(string side)
    {
        // TODO: Add all upgrades
        if (side == "left")
        {
            switch (uiManager.leftShopText.text)
            {
                case "MOVE FASTER\nON BEAT":
                    moveFasterOnBeatUpgrade = true;
                    break;
                default:
                    break;
            }
        }
        else if (side == "right")
        {
            switch (uiManager.rightShopText.text)
            {
                case "SPLIT SHOT\nON SNARE":
                    splitShotOnSnareUpgrade = true;
                    break;
                default:
                    break;
            }
        }
    }

    private IEnumerator MovementBoost()
    {
        isMovementBoostActive = true;
        moveSpeed = 5;
        yield return new WaitForSeconds(0.25f);
        moveSpeed = 2;
        yield return new WaitForSeconds(0.25f);
        isMovementBoostActive = false;
    }
}
