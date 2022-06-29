using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
  // Start is called before the first frame update
  public string levelName;

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag(TagManager.PLAYER_TAG))
    {
      SceneManager.LoadScene(levelName);

    }
  }
}
