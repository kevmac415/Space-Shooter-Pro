using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move down at a speed of 3 (adjust in the inspector)
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        //when we leave the screen, destroy this object
        if (transform.position.y < -5f)
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
                player.TripleShotActive();
            }
            Destroy(this.gameObject);
        }
    }
}
