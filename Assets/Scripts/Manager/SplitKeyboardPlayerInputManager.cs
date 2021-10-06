using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SplitKeyboardPlayerInputManager : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;



    private Dictionary<int, PlayerInput> existingPlayerInputs = new Dictionary<int, PlayerInput>();
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void JoinPlayer(int playerIndex, string controlScheme) //creates player one
    {

        if (!existingPlayerInputs.ContainsKey(playerIndex = 0))
        {
            //instantiates the player and then assigns the control scheme
            
            var playerInput = PlayerInput.Instantiate(prefab, controlScheme: controlScheme, playerIndex: playerIndex, pairWithDevice: Keyboard.current);


            playerInput.SwitchCurrentControlScheme(controlScheme);
            
            existingPlayerInputs.Add(playerIndex, playerInput);
            
            SendMessage("OnPlayerJoined", playerInput);
            
        }


        
   }


        public void JoinPlayer2(int playerIndex, string controlScheme) //creates player two
        {
        
        if (!existingPlayerInputs.ContainsKey(playerIndex = 1))
        {
            //instantiates the player and then assigns the control scheme
            
            var playerInput = PlayerInput.Instantiate(prefab, controlScheme: controlScheme, playerIndex: playerIndex, pairWithDevice: Keyboard.current);

            playerInput.SwitchCurrentControlScheme(controlScheme);

            existingPlayerInputs.Add(playerIndex, playerInput);

            SendMessage("OnPlayerJoined", playerInput);


        }

    }

    
    
    //TODO remove player from game and free up playerIndex in existingPlayerInputs
    public void LeavePlayer(int playerIndex = 0)
    {
        var playerInput = existingPlayerInputs[playerIndex];


        if (existingPlayerInputs.ContainsKey(playerIndex))
        {
            
            //var P1 = playerInput.gameObject; //TRYING to destroy the player so far it only destroys the controller

            PlayerInput.Destroy(playerInput.gameObject);

            //playerInput.gameObject.SetActive(false);



            SendMessage("OnPlayerLeft", playerInput);

            existingPlayerInputs.Remove(playerIndex);
            //existingPlayerInputs.Clear();

        }

    }

    public void LeavePlayer2(int playerIndex = 1)
    {
        var playerInput = existingPlayerInputs[playerIndex];

        if (existingPlayerInputs.ContainsKey(playerIndex))
        {
            //var P2 = playerInput.gameObject;
           
            //Destroy(P2);

        
        Destroy(playerInput.gameObject);

        //playerInput.gameObject.SetActive(false);

        //PlayerInput.Destroy(playerInput.gameObject);

        SendMessage("OnPlayerLeft", playerInput);


            existingPlayerInputs.Remove(playerIndex);
            //existingPlayerInputs.Clear();

        }


    }
}
