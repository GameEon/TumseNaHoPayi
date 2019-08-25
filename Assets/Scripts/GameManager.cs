using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Controls communication between all game objects and responsible
 * for resetting the game
*/

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }
    Player player;
    public Ground[] allGrounds;
    public GroundWithSpikes[] allGroundsWithSpikes;
    public GameObject playerWinMessage;

    void Start()
    {
        allGrounds = FindObjectsOfType<Ground>();
        allGroundsWithSpikes = FindObjectsOfType<GroundWithSpikes>();
        player = FindObjectOfType<Player>();
        player.CanControl(true);
    }

    public void ResetGame()
    {
        player.CanControl(true);
        for (int i = 0; i < allGrounds.Length; i++)
        {
            allGrounds[i].GlobalReset();
        }
        for (int i = 0; i < allGroundsWithSpikes.Length; i++)
        {
            allGroundsWithSpikes[i].ResetSpikes();
        }
    }

    public void LevelComplete()
    {
        print("Hurray! You completed the level!");
        player.CanControl(false);
        playerWinMessage.GetComponent<MoveToTransition>().PlayerWon();
    }
}
