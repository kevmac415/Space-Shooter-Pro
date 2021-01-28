﻿using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    //_Variables_ 
    //public or private reference 
    //data type (int, float, bool, string)
    //every variable has a name
    //optional value assigned
    
    [SerializeField] //Lets you read and use the slider tool in unity even on private
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _canFire = -1f;
    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;

    
    void Start()
    {
        //take the current position = new position (0, 0, 0) - starting position
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();//find the object, get the component
        if (_spawnManager == null)
        {
            Debug.LogError("The spawn manager is null.");
        }
    } 

    // Update is called once per frame
    void Update() {
        CalculateMovement();
        
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }
        
    }
        void CalculateMovement() {
            
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);  //direction is a variable holding the code above
            
            //transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
            //transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
            transform.Translate(direction * _speed * Time.deltaTime);
                                                                                            //converted 1 meter per frame to one second per frame with the Time.deltaTime representing real life seconds.
                                                                                            //equivalent to incorporating real time 

            if (transform.position.y >= 0) {
                transform.position = new Vector3(transform.position.x, 0, 0); //These next two if statements create the boundaries
            } else if(transform.position.y <= -3.8f) {
                transform.position =  new Vector3(transform.position.x, -3.8f, 0);
            }
            //transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);
            
            if (transform.position.x >= 11.3f) {
                transform.position = new Vector3(-11.3f, transform.position.y, 0);
            } else if(transform.position.x <= -11.3f) {
                transform.position = new Vector3(11.3f, transform.position.y, 0);
            }
            //if player on the x > 11
            //x pos = -11
            //else if player on the x is less than -11
            //x pos = 11
        }

        void FireLaser()
                                    //if i hit the space key im going to spawn gameObject
            {
                _canFire = Time.time + _fireRate;
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity); //creates laser and transforms it to the 0.8f position above the player, This quaternion corresponds to "no rotation" - the object is perfectly aligned with the world or parent axes. 
            }

        public void Damage()        //public so that enemy can get this
        {
            _lives -= 1;            //or _lives --; or _lives = _lives - 1;
                                    //check if dead, if are then destroy us
            if (_lives < 1)
            {
                //communicate with spawn manager to stop spawning on death
                _spawnManager.OnPlayerDeath();
                Destroy(this.gameObject);
            }
        }
}