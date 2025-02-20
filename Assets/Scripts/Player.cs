using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Android;

public class Player : MonoBehaviour
{
    public FixedJoystick moveJoystick;
    public FixedJoystick aimJoystick;
    public Rigidbody2D rigidBody;
    public SpriteRenderer playerSprite => GetComponent<SpriteRenderer>();
    public Bullet bulletPrefab;
    public GameObject shooter;
    public GameObject leftShooter;
    public GameObject rightShooter;
    public ColorManager colorManager = new ColorManager();
    public float moveSpeed = 2;
    private bool canShoot = true;
    private bool canMove = true;
    public UIManager uiManager;
    public bool splitShotOnSnareUpgrade = false;
    public bool moveFasterOnBeatUpgrade = false;
    public bool movementSpeedUpgrade = false;
    public bool fireOnOffBeatUpgrade = false;
    private bool isMovementBoostActive = false;
    private bool isSplitShotActive = false;

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

        leftShooter.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, 45);
        leftShooter.transform.position = transform.position + transform.up * 0.25f + transform.right * -0.25f;

        rightShooter.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, -45);
        rightShooter.transform.position = transform.position + transform.up * 0.25f + transform.right * 0.25f;
    }

    public void Move()
    {
        Vector2 moveVector = new Vector2(moveJoystick.Horizontal, moveJoystick.Vertical);
        if (canMove)
        {
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
        if (splitShotOnSnareUpgrade && !isSplitShotActive)
        {
            StartCoroutine(SplitShot());
        }
        Bullet bullet = Instantiate(bulletPrefab, shooter.transform.position, shooter.transform.rotation);
        bullet.rigidBody.AddForce(shooter.transform.up * 8f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(fireOnOffBeatUpgrade ? 0.33f : 0.5f);
        canShoot = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "LeftShopCircle")
        {
            uiManager.upgradeSelected = true;
            StartCoroutine(UpgradePlayer("left"));
        }
        else if (collision.gameObject.name == "RightShopCircle")
        {
            uiManager.upgradeSelected = true;
            StartCoroutine(UpgradePlayer("right"));
        }

        // ! Uncomment when game is finished
        // switch (collision.gameObject.name)
        // {
        //     case "BaseEnemy(Clone)":
        //     case "FastEnemy(Clone)":
        //     case "TankEnemy(Clone)":
        //     case "SentryEnemy(Clone)":
        //     case "SentryBullet(Clone)":
                 // TODO: Add death animation
        //         UnityEngine.SceneManagement.SceneManager.LoadScene(3);
        //         break;
        //     default:
        //         break;
        // }
    }

    public IEnumerator MovePlayerInShop()
    {
        canMove = false;
        Vector2 initialPosition = transform.position;
        Vector2 targetPosition = new Vector2(0, -1.7f);
        for (float t = 0.0f; t < 1f; t += Time.deltaTime)
        {
            transform.position = Vector2.Lerp(initialPosition, targetPosition, t);
            yield return null;
        }
        canMove = true;
    }

    private IEnumerator UpgradePlayer(string side)
    {
        yield return StartCoroutine(uiManager.FadeOutText(uiManager.leftShopText, uiManager.rightShopText));
        if (side == "left")
        {
            switch (uiManager.leftShopText.text)
            {
                case "MOVE FASTER\nON BEAT":
                    moveFasterOnBeatUpgrade = true;
                    uiManager.leftShopText.text = "INCREASE\nMOVEMENT SPEED";
                    break;
                case "INCREASE\nMOVEMENT SPEED":
                    movementSpeedUpgrade = true;
                    uiManager.leftShopText.text = "DIE";
                    break;
                case "DIE":
                    uiManager.UpdateCenterText("");
                    uiManager.UpdateTopText("");
                    UnityEngine.SceneManagement.SceneManager.LoadScene(4);
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
                    uiManager.rightShopText.text = "FIRE ON\nOFF-BEAT";
                    break;
                case "FIRE ON\nOFF-BEAT":
                    fireOnOffBeatUpgrade = true;
                    uiManager.rightShopText.text = "DIE";
                    break;
                case "DIE":
                    uiManager.UpdateCenterText("");
                    uiManager.UpdateTopText("");
                    UnityEngine.SceneManagement.SceneManager.LoadScene(4);
                    break;
                default:
                    break;
            }
        }
    }

    private IEnumerator MovementBoost()
    {
        isMovementBoostActive = true;
        moveSpeed = 4;
        yield return new WaitForSeconds(0.25f);
        moveSpeed = movementSpeedUpgrade ? 3 : 2;
        yield return new WaitForSeconds(0.25f);
        isMovementBoostActive = false;
    }

    private IEnumerator SplitShot()
    {
        isSplitShotActive = true;
        leftShooter.SetActive(true);
        rightShooter.SetActive(true);

        Bullet bullet1 = Instantiate(bulletPrefab, leftShooter.transform.position, leftShooter.transform.rotation);
        bullet1.rigidBody.AddForce(leftShooter.transform.up * 8f, ForceMode2D.Impulse);

        Bullet bullet2 = Instantiate(bulletPrefab, rightShooter.transform.position, rightShooter.transform.rotation);
        bullet2.rigidBody.AddForce(rightShooter.transform.up * 8f, ForceMode2D.Impulse);

        if (fireOnOffBeatUpgrade)
        {
            yield return new WaitForSeconds(0.25f);
             Bullet bullet3 = Instantiate(bulletPrefab, leftShooter.transform.position, leftShooter.transform.rotation);
            bullet3.rigidBody.AddForce(leftShooter.transform.up * 8f, ForceMode2D.Impulse);

            Bullet bullet4 = Instantiate(bulletPrefab, rightShooter.transform.position, rightShooter.transform.rotation);
            bullet4.rigidBody.AddForce(rightShooter.transform.up * 8f, ForceMode2D.Impulse);
        }
        yield return new WaitForSeconds(1.25f);
        leftShooter.SetActive(false);
        rightShooter.SetActive(false);
        isSplitShotActive = false;
    }

}
