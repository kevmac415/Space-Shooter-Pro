﻿using System.Diagnostics.Contracts;
using System.Security;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    
    [SerializeField] //ID for powerups  0 = triple shot, 1 = speed, 2 = shields
    private int powerupID;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        
        if (transform.position.y < -5f) //when we leave the screen, destroy this object
        {
            Destroy(this.gameObject);
        }
    }

    //ontriggercollision
    //only be collectible by the player(hint: use tags)
    //on collected destroy
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //communicate with the player script
            //create a handle to the component i want
            //then assign the handle to the component
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                switch (powerupID)
                {
                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedBoostActive();
                        break;
                    case 2:
                        player.ShieldsActive();
                        break;
                    default:
                        Debug.Log("Deafault Value");
                        break;
                }
            }
            Destroy(this.gameObject);
        }
    }
}
