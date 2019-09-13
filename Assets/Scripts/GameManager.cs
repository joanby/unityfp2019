using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

  
    private int numberOfEnemies = 0;
    private int score = 0;

    private float totalTime = 0;


    public bool showWinScreen = false, showLoseScreen = false;

    private int playerHP = 3;
    public int HP {
        get { return playerHP; }
        set{
            playerHP = value;
            if(playerHP<=0){
                Debug.Log("GAME OVER");
                Time.timeScale = 0;
                showLoseScreen = true;
            }
        }
    }


    public string labelText = "Recoge los 4 objetos y gana!";
    public int maxItems = 4;


    private int itemsCollected = 0;
    public int Items{
        get { return itemsCollected; }
        set{
            itemsCollected = value;
            Debug.LogFormat("Items: {0}", itemsCollected);


            if(itemsCollected >= maxItems){
                showWinScreen = true;
                Time.timeScale = 0;
                labelText = "Has encontrado todos los ítems";
            }else{
                labelText = "Item econtrado. Faltan: " + (maxItems - itemsCollected);
            }
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




    private void Update()
    {
        totalTime += Time.deltaTime;
    }


    private void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 50), "Player Health: " + playerHP);
        GUI.Box(new Rect(20, 90, 150, 50), "Items collected: " + itemsCollected);
        GUI.Box(new Rect(20, 150, 150, 50), "Record Previo: " + PlayerPrefs.GetFloat("record", 999999));

        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 200, 50),
                  labelText);

        if(showWinScreen){
            if(GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 100,
                                   400, 200), "GAME OVER!\n"+totalTime)){
                float previousRecord = PlayerPrefs.GetFloat("record", 999999);

                if(previousRecord >= totalTime){
                    PlayerPrefs.SetFloat("record", totalTime);
                }

                RestartLevel();
            }
        }

        if (showLoseScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 100,
                                   400, 200), "GAME OVER!\n Has perdido"))
            {
                RestartLevel();

            }
        }
    }


    void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
