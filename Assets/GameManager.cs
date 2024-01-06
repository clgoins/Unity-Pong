using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int p1Score = 0;
    public int p2Score = 0;
    [SerializeField] private Transform ballPos;
    [SerializeField] private GameObject ballPrefab;
    private GameObject currentBall;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Canvas scoreBoard;
    [SerializeField] private TextMeshProUGUI p1ScoreText;
    [SerializeField] private TextMeshProUGUI p2ScoreText;
    [SerializeField] private Canvas gameOverScreen;
    [SerializeField] private TextMeshProUGUI winnerText;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject leftBumper;
    [SerializeField] private GameObject rightBumper;
    [SerializeField] private GameObject aiBumper;
    private bool isGameOver;


    // Start is called before the first frame update
    void Start()
    {
        isGameOver = true;
        gameOverScreen.enabled = false;
        scoreBoard.enabled = false;
        mainMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            if (mainCamera.WorldToScreenPoint(ballPos.position).x < 0)
            {
                GameObject.Destroy(currentBall);
                currentBall = GameObject.Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
                ballPos = currentBall.transform;
                currentBall.GetComponent<Ball>().Init();

                p2Score++;
                p2ScoreText.text = "" + p2Score;
                if (p2Score > 9)
                    gameOver(2);
            }

            if (mainCamera.WorldToScreenPoint(ballPos.position).x > Screen.width)
            {
                GameObject.Destroy(currentBall);
                currentBall = GameObject.Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
                ballPos = currentBall.transform;
                currentBall.GetComponent<Ball>().Init();

                p1Score++;
                p1ScoreText.text = "" + p1Score;
                if (p1Score > 9)
                    gameOver(1);
            }
        }
        
        if (isGameOver && !mainMenu.activeSelf)
        {
            if (Input.anyKeyDown)
            {
                mainMenu.SetActive(true);
                gameOverScreen.enabled = false;
            }
        }
    }

    public void gameOver(int winner)
    {
        isGameOver = true;
        leftBumper.SetActive(false);
        rightBumper.SetActive(false);
        aiBumper.SetActive(false);
        scoreBoard.enabled = false;
        winnerText.text = "Player " + winner + " wins";
        gameOverScreen.enabled = true;
        GameObject.Destroy(currentBall);
    }

    public void newGame(int playerCount)
    {
        isGameOver = false;
        scoreBoard.enabled = true;
        mainMenu.SetActive(false);


        leftBumper.SetActive(true);
        if (playerCount == 1)
            aiBumper.SetActive(true);
        else
            rightBumper.SetActive(true);


        currentBall = GameObject.Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
        ballPos = currentBall.transform;
        currentBall.GetComponent<Ball>().Init();
    }
}
