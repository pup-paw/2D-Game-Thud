using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameObject gameOverText;
    public bool gameOver = false;
    public GameObject youWinText;
    public int maxGem = 5;
    public int myGem = 0;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (myGem == 5) PlayerWin();
    }

    public void PlayerDied()
    {
        gameOverText.SetActive(true); gameOver = true;
    }

    public void PlayerWin()
    {
        youWinText.SetActive(true); gameOver = true;
    }
}
