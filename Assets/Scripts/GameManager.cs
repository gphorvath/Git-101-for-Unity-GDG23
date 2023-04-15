using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Borrowed code from here: https://www.awesomeinc.org/tutorials/unity-pong/

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public TMP_Text Player1ScoreUI;
    public TMP_Text Player2ScoreUI;
    public int PlayerScore1 = 0;
    public int PlayerScore2 = 0;

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
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Score(string wallID)
    {
        if (wallID == "RightWall")
        {
            PlayerScore1++;
            Player1ScoreUI.text = PlayerScore1.ToString();
        }
        else
        {
            PlayerScore2++;
            Player2ScoreUI.text = PlayerScore2.ToString();
        }
    }

}
