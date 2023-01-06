using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private GameController gameController;
    public GameObject pnMenu, pnGame, pnPause, pnResume, pnGameOver;
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void ButtonExit() {
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call<bool>("moveTaskToBack", true);
    }

    public void ButtonStartGame() {
        gameController.StartGame();
        pnMenu.SetActive(false);
        pnGame.SetActive(true);
    }

    public void ButtonPause() {
        pnResume.SetActive(false);
        pnPause.SetActive(true);    
    }

    public void ButtonResume() {
        pnResume.SetActive(true);
        pnPause.SetActive(false);
    }

    public void ButtonRestart() {
        pnGame.SetActive(true);
        pnPause.SetActive(false);
        pnGameOver.SetActive(false);
    }

    public void ReturnMenu() {
        pnGame.SetActive(false);
        pnPause.SetActive(false);   
        pnMenu.SetActive(true);
        gameController.BackMenu();
    }

}
