using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float currentTime;
    [SerializeField] float startedTime;
    public int score;
    public bool gameStarted;

    private UIController uiController;
    void Start()
    {
        gameStarted = false;
        uiController = FindObjectOfType<UIController>();    
    }

    private void Update() {
        
    }

    public void InvokeSubtractTime() {
        InvokeRepeating("SubtractTime", 1f, 1f);
    }

    public void StartGame() {
        score = 0;
        currentTime = startedTime;
        gameStarted = true;
        InvokeSubtractTime();
    }

    public void BackMenu() {
        score = 0;
        currentTime = 0;
        gameStarted = false;
        CancelInvoke("SubtractTime");
    }

    void SubtractTime() {
        if (currentTime > 0f && gameStarted) {
            currentTime -= 1f;
        }
        else {
            uiController.pnGameOver.SetActive(true);
            uiController.pnGame.SetActive(false);
            gameStarted = false;
            currentTime = 0f;
            CancelInvoke("SubtractTime");
            return;
        }

    }


}
