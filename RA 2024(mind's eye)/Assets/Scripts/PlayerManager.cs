using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public bool gameOver = false;
    [SerializeField] PlayerController b;
    public GameObject gameOverUI;

    void Awake()
    {
        b = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameOver= b.GetGameOver();
        if (gameOver || Input.GetKeyDown(KeyCode.Escape)){
            GameOver();            
            //restart
        }
    }
    public void GameOver(){
        gameOverUI.SetActive(true);
    }
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit(){
        SceneManager.LoadScene("MainScene");
    }
}
