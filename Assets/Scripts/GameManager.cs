using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

  public GameOverManager gameOverManager;
  public EndGameManager endGameManager;
  public static bool isFinish = false;

  private PlayerManager playerManager;
  void Start()
  {
    isFinish = false;
    playerManager = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).GetComponent<PlayerManager>();
  }

  void Update()
  {
    if (playerManager.healthSystem.IsDead())
    {
      GameOver();
    }
    if (isFinish)
    {
      Debug.Log("FINISH");
      FinishGame();
    }
  }
  public void FinishGame()
  {
    endGameManager.Setup();
  }
  public void GameOver()
  {
    gameOverManager.Setup();
  }

  public void RestartGame()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  public void MainMenu()
  {
    SceneManager.LoadScene("MainMenu");
  }

  public void QuitGame()
  {
    Application.Quit();
    Debug.Log("Game is exiting");
  }
}
