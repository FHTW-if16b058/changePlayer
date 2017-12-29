using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class RoundController : MonoBehaviour {

    public static RoundController instance = null;              // singleton
    int[] playerCards = new int[4] { 5, 6, 7, 8 };
    int currentPlayer;
    int turn = 1;
    //Text player;
    //Text card;
    //Text oppLeft;
    //Text teammate;
    //Text oppRight;

	// Use this for initialization
	void Awake ()
    {
        if (instance == null)                                   // also important for singleton-thing
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        // set first player
        StartRound(0);
    }

    public void StartRound(int firstPlayer)
    {
        Debug.Log("starting round");
        turn = 1;
        Debug.Log("turn = " + turn.ToString());
        currentPlayer = firstPlayer;
        Debug.Log("first player = " + firstPlayer.ToString());
        DisplayTable();
    }

    void EndRound()
    {
        Debug.Log("ending round");
        // caluclate scores
        // if scores < target score...
            // set 'first player'
            // start next round
            StartRound((int)Random.Range(0f, 3f));
    }

    public void GoAhead()
    {
        Scene scene = SceneManager.GetActiveScene();

        Debug.Log("turn = " + turn.ToString());
        if (scene.name == "game")
        {
            if (turn < 5)
            {                
                int i = currentPlayer + 1;
                currentPlayer = i % 4;
                //Debug.Log("player changed = " + currentPlayer.ToString());
                turn++;
            }

            if (turn == 5)
            {
                this.EndRound();
            }
            else
            {
                SwitchScene("change");
            }
        }
        else if (scene.name == "change")
        {
            SwitchScene("game");
        }
    }

    void SwitchScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "game")
        {
            DisplayTable();
        }
    }

    void DisplayTable()
    {
        // current player
        GameObject.Find("TxtPlayerData").GetComponent<Text>().text = currentPlayer.ToString();
        GameObject.Find("TxtCardData").GetComponent<Text>().text = playerCards[currentPlayer].ToString();

        //  display other players (new)
        int l = (currentPlayer + 1) % 4;
        int t = (currentPlayer + 2) % 4;
        int r = (currentPlayer + 3) % 4;
        GameObject.Find("TxtOppLeftData").GetComponent<Text>().text = l.ToString();
        GameObject.Find("TxtTeammateData").GetComponent<Text>().text = t.ToString();
        GameObject.Find("TxtOppRightData").GetComponent<Text>().text = r.ToString();

        // adapt button text
        Text buttonText = GameObject.Find("BtnChange").GetComponentInChildren<Text>();
        if (turn < 4)
        {
            buttonText.text = "Change Player";
        }
        else
        {
            buttonText.text = "End Round";
        }
    }
}
