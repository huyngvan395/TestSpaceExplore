using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Central game state machine and singleton manager.
/// Controls game flow: Playing, Paused, GameOver, Victory.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameState { MainMenu, Playing, Paused, GameOver, Victory }
    public GameState CurrentState { get; private set; } = GameState.Playing;

    [Header("Scene Names")]
    public string mainMenuScene = "MainMenu";
    public string area1Scene = "Area1_AuroraNebula";
    public string area2Scene = "Area2_AsteroidFrontier";
    public string area3Scene = "Area3_BlackHoleCore";

    // Events that UI/other systems can subscribe to
    public static System.Action<GameState> OnStateChanged;
    public static System.Action OnGameOver;
    public static System.Action OnVictory;
    public static System.Action OnPaused;
    public static System.Action OnResumed;

    private void Awake()
    {
        // Singleton pattern — persist across scenes
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (CurrentState == GameState.Playing || CurrentState == GameState.Paused)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
            {
                TogglePause();
            }
        }
    }

    public void SetState(GameState newState)
    {
        if (CurrentState == newState) return;
        CurrentState = newState;
        OnStateChanged?.Invoke(newState);

        switch (newState)
        {
            case GameState.Paused:
                Time.timeScale = 0f;
                OnPaused?.Invoke();
                break;
            case GameState.Playing:
                Time.timeScale = 1f;
                OnResumed?.Invoke();
                break;
            case GameState.GameOver:
                Time.timeScale = 0f;
                OnGameOver?.Invoke();
                break;
            case GameState.Victory:
                Time.timeScale = 0f;
                OnVictory?.Invoke();
                break;
            case GameState.MainMenu:
                Time.timeScale = 1f;
                break;
        }
    }

    public void TogglePause()
    {
        if (CurrentState == GameState.Playing)
            SetState(GameState.Paused);
        else if (CurrentState == GameState.Paused)
            SetState(GameState.Playing);
    }

    public void TriggerGameOver()
    {
        SetState(GameState.GameOver);
    }

    public void TriggerVictory()
    {
        SetState(GameState.Victory);
    }

    public void RestartCurrentScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SetState(GameState.MainMenu);
        SceneManager.LoadScene(mainMenuScene);
    }

    public void LoadArea(int areaNumber)
    {
        Time.timeScale = 1f;
        SetState(GameState.Playing);
        switch (areaNumber)
        {
            case 1: SceneManager.LoadScene(area1Scene); break;
            case 2: SceneManager.LoadScene(area2Scene); break;
            case 3: SceneManager.LoadScene(area3Scene); break;
        }
    }

    public bool IsPlaying => CurrentState == GameState.Playing;
}
