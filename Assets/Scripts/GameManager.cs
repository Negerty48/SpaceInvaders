using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject playerShip;
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
                break;
            case GameManagerState.GamePlay:
                break;
            case GameManagerState.GameOver:
                break;
        }
    }

    public void SetGameManagerState(GameManagerState state) 
    {
        GMState = state;
        UpdateGameManagerState();
    }
}
