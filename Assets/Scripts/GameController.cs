using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float currentTime;
    [SerializeField] float startedTime;
    public int score;
    public bool gameStarted;
    void Start()
    {
        score = 0;
        currentTime = startedTime;
        gameStarted = true;
    }

    private void Update() {
        subtractTime();
    }

    void subtractTime() {
        if (currentTime > 0f && gameStarted) {
            currentTime -= Time.deltaTime;
            float currentTimeint = Mathf.FloorToInt(currentTime);
            Debug.Log(currentTimeint);
        }
        else {
            gameStarted= false; 
            currentTime = 0f;
            return;
        }

    }


}
