using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int numberOfEnemies = 0;
    private int score = 0;



    private int playerHP = 3;
    public int HP {
        get { return playerHP; }
        set{
            playerHP = value;
            if(playerHP<=0){
                Debug.Log("GAME OVER");
            }
        }
    }



    private int itemsCollected = 0;
    public int Items{
        get { return itemsCollected; }
        set{
            itemsCollected = value;
            Debug.LogFormat("Items: {0}", itemsCollected);
        }
    }


    private string _playerName;
    public string PlayerName { 
        get{
            return _playerName;
        } 

        set{
            _playerName = value;
        } 
    } 



    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
