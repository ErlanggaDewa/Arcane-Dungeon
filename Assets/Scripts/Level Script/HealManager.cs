using UnityEngine;

public class HealManager : MonoBehaviour
{
  PlayerManager playerManager;
  // Start is called before the first frame update
  void Start()
  {
    playerManager = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).GetComponent<PlayerManager>();
  }
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag(TagManager.PLAYER_TAG))
    {
      playerManager.healthSystem.HealComplete();
      Destroy(gameObject);
    }
  }
}
