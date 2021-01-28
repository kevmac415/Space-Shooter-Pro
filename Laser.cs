using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8.0f;
    //speed variable of 8

    // Update is called once per frame
    void Update()
    {
        //translate laser up
        transform.Translate(Vector3.up * _speed * Time.deltaTime); //Vector3.up is equivalent to Vector3(0, 1, 0)

        //if laser position is greater than 8 on the y, destroy the object
        if (transform.position.y > 8f) {
            Destroy(this.gameObject);
        }
    }
}
