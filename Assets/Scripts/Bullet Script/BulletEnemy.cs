using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
  GameObject playerTarget;
  Rigidbody2D bulletRb;
  Vector2 moveDirection;
  public float bulletSpeed;
  public float damage;

  void Start()
  {
    bulletRb = gameObject.GetComponent<Rigidbody2D>();
    playerTarget = GameObject.FindWithTag(TagManager.PLAYER_TAG);
    moveDirection = (playerTarget.transform.position - transform.position).normalized * bulletSpeed;
    bulletRb.velocity = new Vector2(moveDirection.x, moveDirection.y);
  }

  // Update is called once per frame

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag(TagManager.BLOCKING_TAG) || other.CompareTag(TagManager.PLAYER_TAG) || other.CompareTag(TagManager.GATE))
    {
      Destroy(gameObject);
    }
  }
}
