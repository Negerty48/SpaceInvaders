using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject scoreUIText;
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner;
    public GameObject GameOver;
    public enum GameManagerState {
        Opening,
        GamePlay,
        GameOver
    }

    GameManagerState GMState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GMState = GameManagerState.Opening;
    }

    // Update is called once per frame
    void UpdateGameManagerState()
    {
        switch(GMState) {
            case GameManagerState.Opening:
                GameOver.SetActive(false);
                playButton.SetActive(true);
                break;
            case GameManagerState.GamePlay:
                scoreUIText.GetComponent<GameScore>().Score = 0;
                playButton.SetActive(false);
                playerShip.GetComponent<PlayerControll>().Init();
                enemySpawner.GetComponent<EnemySpawner>().StartEnemySpawner();
                break;
            case GameManagerState.GameOver:
                enemySpawner.GetComponent<EnemySpawner>().StopEnemySpawner();
                GameOver.SetActive(true);
                Invoke("ChangeToOpeningState", 3f);
                break;
        }
    }

    public void SetGameManagerState(GameManagerState state) 
    {
        GMState = state;
        UpdateGameManagerState();
    }

    public void StartGamePlay()
    {
        GMState = GameManagerState.GamePlay;
        UpdateGameManagerState();
    }

    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }
}
