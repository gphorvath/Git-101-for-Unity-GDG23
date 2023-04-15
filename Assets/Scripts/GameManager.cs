using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Borrowed code from here: https://www.awesomeinc.org/tutorials/unity-pong/

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public TMP_Text victoryBanner;
    public TMP_Text player1ScoreUI;
    public TMP_Text player2ScoreUI;
    public int playerScore1 = 0;
    public int playerScore2 = 0;
    public int finalScore = 3;

    GameObject theBall;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");
        victoryBanner.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Score(string wallID)
    {
        if (wallID == "RightWall")
        {
            playerScore1++;
        }
        else
        {
            playerScore2++;
        }
        CheckGameState();
    }

    private void CheckGameState()
    {
        UpdateUI();
        // Player 1 Victory
        if (playerScore1 > (finalScore - 1))
        {
            victoryBanner.text = "Player 1 Wins!";
            StartCoroutine(VictoryState());
            return;
        }

        // Player 2 Victory
        if (playerScore2 > (finalScore - 1))
        {
            victoryBanner.text = "Player 2 Wins!";
            VictoryState();
            StartCoroutine(VictoryState());
            return;
        }

        // ContinueGame
        FindObjectOfType<BallController>().RestartGame();
    }

    private void UpdateUI()
    {
        player1ScoreUI.text = playerScore1.ToString();
        player2ScoreUI.text = playerScore2.ToString();
    }

    private void NewGame()
    {
        playerScore1 = 0;
        playerScore2 = 0;
        CheckGameState();
    }

    IEnumerator VictoryState()
    {
        victoryBanner.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);

        victoryBanner.gameObject.SetActive(false);

        NewGame();

        yield return null;
    }

}
