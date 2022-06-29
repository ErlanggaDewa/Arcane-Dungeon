using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
  public float enemyMovementSpeed;
  private PlayerMovement player;
  Rigidbody2D rbEnemy;
  private Vector2 direction;
  private Vector3 tempScale;
  public bool isCatchingPlayer;

  Vector2 moveDirection;

  // Start is called before the first frame update
  void Start()
  {
    rbEnemy = GetComponent<Rigidbody2D>();
    player = GameObject.FindObjectOfType<PlayerMovement>();

  }

  void OnTriggerEnter2D(Collider2D other)
  {

  }

  void FixedUpdate()
  {
    if (isCatchingPlayer)
    {
      EnemyHandlerMovement();
    }
  }

  private void EnemyHandlerMovement()
  {
    direction = (player.transform.position - transform.position).normalized;
    moveDirection = direction * enemyMovementSpeed;
    rbEnemy.velocity = new Vector2(moveDirection.x, moveDirection.y);

    if (direction.x < 0)
      transform.localScale = new Vector3(-1, 1, 1);
    else
      transform.localScale = new Vector3(1, 1, 1);
  }

  public bool GetEnemyCatchingStatus()
  {
    return this.isCatchingPlayer;
  }
}
