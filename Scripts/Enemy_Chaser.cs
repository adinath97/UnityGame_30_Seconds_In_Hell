using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Chaser : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D Rb;

    private void Start()
    {
        Rb = this.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        ShootPlayer();
    }

    private void ShootPlayer()
    {
        Vector3 relativePos = player.transform.position - transform.position;
        float angle = Mathf.Atan2(relativePos.x, relativePos.y) * Mathf.Rad2Deg;
        Rb.rotation = -angle + 180;
        //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, .01f);
    }
}
