using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
    [SerializeField] private GameObject leftBumper;
    [SerializeField] private GameObject rightBumper;
    [SerializeField] private GameObject aiBumper;
    private bool isGameOver;
    [SerializeField] private AudioSource clickSound;


    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        scoreBoard.enabled = true;
        gameOverScreen.enabled = false;


        leftBumper.SetActive(true);


        if (aiBumper)
            aiBumper.SetActive(true);
        else if (rightBumper)
            rightBumper.SetActive(true);


        currentBall = GameObject.Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
        ballPos = currentBall.transform;
        currentBall.GetComponent<Ball>().Init();
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

                clickSound.Play();

                p2Score++;
                p2ScoreText.text = "" + p2Score;
                if (p2Score > 1)
                    gameOver(2);
            }

            if (mainCamera.WorldToScreenPoint(ballPos.position).x > Screen.width)
            {
                GameObject.Destroy(currentBall);
                currentBall = GameObject.Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
                ballPos = currentBall.transform;
                currentBall.GetComponent<Ball>().Init();

                clickSound.Play();

                p1Score++;
                p1ScoreText.text = "" + p1Score;
                if (p1Score > 1)
                    gameOver(1);
            }
        }
        
        if (isGameOver)
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

    public void gameOver(int winner)
    {
        isGameOver = true;
        leftBumper.SetActive(false);

        if (rightBumper)
            rightBumper.SetActive(false);

        if (aiBumper)
            aiBumper.SetActive(false);

        scoreBoard.enabled = false;
        winnerText.text = "Player " + winner + " wins";
        gameOverScreen.enabled = true;
        GameObject.Destroy(currentBall);
    }

    public void newGame(int playerCount)
    {

    }
}
