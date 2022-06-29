using UnityEngine;
using UnityEngine.SceneManagement;


public class Portal : MonoBehaviour
{
  EnemyManager enemyManager;
  public float targetTotalEnemies;
  public bool isFinalLevel;
  void Awake()
  {
    enemyManager = GameObject.FindGameObjectWithTag(TagManager.ENEMY_TAG).GetComponent<EnemyManager>();
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    EnemyManager[] enemiesManager = FindObjectsOfType<EnemyManager>();

    if (other.gameObject.CompareTag(TagManager.PLAYER_TAG) && enemiesManager.Length == 0)
    {
      if (isFinalLevel)
        GameManager.isFinish = true;
      else
        SceneManager.LoadScene("Level 2");
    }
  }
}
