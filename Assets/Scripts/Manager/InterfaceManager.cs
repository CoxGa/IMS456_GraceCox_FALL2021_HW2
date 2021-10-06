using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    [SerializeField]
    private Button joinPlayerOne;

    [SerializeField]
    private Button joinPlayerTwo;

    [SerializeField]
    private bool isAlive = false;
    
    [SerializeField]
    private bool isAliveP2 = false;

    //TODO: Add PlayerTwoButton reference

    [SerializeField]
    private SplitKeyboardPlayerInputManager playerInputManager;


    // Start is called before the first frame update
    void Start()
    {
        joinPlayerOne.onClick.AddListener(() => JoinPlayerOne());
        
        joinPlayerTwo.onClick.AddListener(() => JoinPlayerTwo());
        
        //TODO Listen for player two click event
    }

  

    private void JoinPlayerOne() //player on is joined, change the button then activate joinPlayerOne in the manager
    {
        if (!isAlive) {
            
            playerInputManager.JoinPlayer(0, "Keyboard&Mouse");

            joinPlayerOne.GetComponentInChildren<Text>().text = "Leave Player One";

            Debug.Log("PLAYER HAS JOIN");

            isAlive = true;
        }

        else //if the player is going to leave, change the button and activate L

        {
            Debug.Log("PLAYER HAS LEFT");

            playerInputManager.LeavePlayer(0);

            
            joinPlayerOne.GetComponentInChildren<Text>().text = "Join Player One";

            isAlive = false;
        }

        //TODO flip text to say "Leave Player One"
        //TODO on click after player has joined, remove player
    }

    
    private void JoinPlayerTwo() //player on is joined, change the button then activate joinPlayerOne in the manager
    {
        if (!isAliveP2)
        {
            playerInputManager.JoinPlayer2(1, "PlayerTwo");

            joinPlayerTwo.GetComponentInChildren<Text>().text = "Leave Player Two";

            Debug.Log("PLAYER 2 HAS JOIN");

            isAliveP2 = true;
        }
        
        else

        {
            Debug.Log("PLAYER 2 HAS LEFT");

            playerInputManager.LeavePlayer2(1);
            
            joinPlayerTwo.GetComponentInChildren<Text>().text = "Join Player Two";

            isAliveP2 = false;
        }

        //TODO flip text to say "Leave Player Two"
        //TODO on click after player has joined, remove player
    }

    //TODO Invoke JoinPlayer passing a playerIndex value and targeting a control scheme
    //TODO flip text after player has joined to say "Leave Player Two"
    //TODO on click after player has joined, remove player
}
