using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool _isGameOver;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && _isGameOver == true) //If you press R
            { 
                SceneManager.LoadScene(0); //Load scene called Game by index, also could use "Game"
            }
    }

    public void GameOver()
    {
        _isGameOver = true;
    }
}
