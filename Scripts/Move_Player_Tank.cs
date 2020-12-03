using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move_Player_Tank : MonoBehaviour
{
    public GameObject playerBullet;
    public GameObject deathExplosion;
    public float explosionDuration = 1f;
    public float countItDown;
    public static bool playerDead;
    public AudioClip playerDeathAudio;
    public float deathAudioVolume = 0.8f;

    public float movementSpeed = 1f;
    public float padding = 1f;
    public float rotationSpeed = 1f;
    public float bulletSpeedX = 10f;
    public float bulletSpeedY = 10f;
    public float bulletSpeed = 10f;
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    float deltaX;
    float deltaY;
    float newXPos;
    float newYPos;
    private bool bottomActivated = false;
    private bool topActivated = false;
    private bool rightSideActivated = false;
    private bool leftSideActivated = false;
    private bool EnemyChaserActivated = false;
    public static bool playerDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        if(Count_Down.beginGame == true)
        {
            MovePlayer();
            if (deltaX != 0 || deltaY != 0)
            {
                RotatePlayer();
            }
        }
    }
        

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        AudioSource.PlayClipAtPoint(playerDeathAudio, Camera.main.transform.position, deathAudioVolume);
        GameObject explosion = Instantiate(deathExplosion, transform.position, transform.rotation);
        Destroy(explosion, explosionDuration);
        StartCoroutine(WaitAndLoad());
        playerDead = true;
        Count_Down.beginGame = false;
        Timer_Manager.startOrNah = 0;
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        SceneManager.LoadScene("GAME_OVER_YOU_LOST");
    }

    private void MovePlayer()
    {
        if(playerDead == false)
        {
            deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
            deltaY = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;

            newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
            newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

            transform.position = new Vector2(newXPos, newYPos);
        }
    }

    private void RotatePlayer()
    {
        if(deltaX != 0)
        {
            float angle = Mathf.Atan2(deltaX, deltaY) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        if(deltaY != 0)
        {
            float angle = Mathf.Atan2(deltaX, -deltaY) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void Fire()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(playerBullet, transform.position, transform.rotation) as GameObject;
            bullet.GetComponent<Rigidbody2D>().velocity = -transform.up * bulletSpeed;
            //bullet.GetComponent<Rigidbody2D>().AddForce(transform.forward * bulletSpeed);
        }
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
}
