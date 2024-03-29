using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float topDistance, lateralMargin;
    private Vector2 screenWidth;
    private GameController gameController;

    private void Awake() {
        Initialize();
    }

    void Start()
    {
        InvokeRepeating("SpawnInvoke", 0f, Random.Range(2.0f, 3.0f));
    }

    private void Initialize() {
        screenWidth = Camera.main.ScreenToWorldPoint(new Vector2(Screen.safeArea.width, Screen.safeArea.height));
        Vector2 heightPosition = new Vector2(transform.position.x, Camera.main.orthographicSize + topDistance);
        transform.position = heightPosition;
        gameController = FindObjectOfType<GameController>();
    } 

    private void SpawnInvoke() {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn() {
        if (gameController.gameStarted) {
            yield return new WaitForSeconds(0f);
            transform.position = new Vector2(Random.Range(-screenWidth.x + lateralMargin, screenWidth.x - lateralMargin), transform.position.y);
            GameObject tempBallPrefab = Instantiate(ballPrefab, transform.position, Quaternion.identity) as GameObject;
        } else {
            yield return null;
        }

        
    }

}
