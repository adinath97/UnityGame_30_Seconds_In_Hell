using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1_Shooting : MonoBehaviour
{
    public float shotCounter;
    public float minTimeBetweenShots = .3f;
    public float maxTimeBetweenShots = 3f;
    public GameObject enemyShot;
    public float enemyShotSpeed = 10f;
    public AudioClip enemyShotAudio;
    public float enemyShotAudioVolume = .8f;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        if(Count_Down.beginGame == true)
        {
            CountDownAndShoot();
        }
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0)
        {
            Enemy1Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Enemy1Fire()
    {
        if (this.tag == "EnemyChaser1")
        {
            AudioSource.PlayClipAtPoint(enemyShotAudio, Camera.main.transform.position, enemyShotAudioVolume);
            GameObject bullet = Instantiate(enemyShot, transform.position, transform.rotation) as GameObject;
            bullet.GetComponent<Rigidbody2D>().velocity = -transform.up * enemyShotSpeed;
        }
        else
        {
            GameObject enemyBullet = Instantiate(enemyShot, transform.position, Quaternion.identity) as GameObject;
            if (this.tag == "Top1")
            {
                if(Timer_Manager.top1Activated == true)
                {
                    AudioSource.PlayClipAtPoint(enemyShotAudio, Camera.main.transform.position, enemyShotAudioVolume);
                }
                enemyBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -enemyShotSpeed);
            }
            if (this.tag == "Bottom1")
            {
                if (Timer_Manager.bottom1Activated == true)
                {
                    AudioSource.PlayClipAtPoint(enemyShotAudio, Camera.main.transform.position, enemyShotAudioVolume);
                }
                enemyBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, enemyShotSpeed);
            }
            if (this.tag == "RightSide1")
            {

                if (Timer_Manager.right1Activated == true)
                {
                    AudioSource.PlayClipAtPoint(enemyShotAudio, Camera.main.transform.position, enemyShotAudioVolume);
                }
                enemyBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-enemyShotSpeed, 0);
                enemyBullet.transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            if (this.tag == "LeftSide1")
            {

                if (Timer_Manager.left1Activated == true)
                {
                    AudioSource.PlayClipAtPoint(enemyShotAudio, Camera.main.transform.position, enemyShotAudioVolume);
                }
                enemyBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(enemyShotSpeed, 0);
                enemyBullet.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
        }
        
    }
} 
