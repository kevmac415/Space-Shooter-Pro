using System.Diagnostics;
using System.Security;
using System.Security.Cryptography;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move down at 4 meters per sec
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        //check for if bottom of screen, respawn at top(Can reuse it not destroy it)
        //respawn at top with a new random x position
        if (transform.position.y < -5f)
        {
            float randomX = Random.Range(-8f, 8f); //assigned the Random.Range to a variable(randomX)
            transform.position = new Vector3(randomX, 7, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if other is player damage player, then destroy us
        if (other.tag == "Player")
        {
            //damage player
            Player player = other.transform.GetComponent<Player>(); //other.transform.GetComponent<Player>().Damage();

            if (player != null)
            {
                player.Damage();
            }

            Destroy(this.gameObject);
        }

        //if other is laser then destroy laser, then destroy us
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);

        }
    }
}
