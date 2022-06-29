using UnityEngine;

public class Bullet : MonoBehaviour
{
  private bool dealthDamage;
  private Rigidbody2D myBody;

  [SerializeField]
  private float moveSpeed = 2.5f;

  [SerializeField]
  private float damageAmount = 25f;

  [SerializeField]
  private float deactivateTimer = 3f;

  [SerializeField]
  private bool destroyObj;

  private PlayerWeaponManager playerWeaponManager;
  public float bulletDamage;



  // Start is called before the first frame update
  private void Awake()
  {

    playerWeaponManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWeaponManager>();

    myBody = GetComponent<Rigidbody2D>();
    // Invoke("DeactivateBullet", deactivateTimer);
  }

  private void Update()
  {
    DeactivateBullet();
  }

  void DeactivateBullet()
  {
    if (destroyObj)
      Destroy(gameObject);
    // else
    //   gameObject.SetActive(false);
  }

  public void MoveInDirection(Vector3 direction)
  {
    myBody.velocity = direction * moveSpeed;
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag(TagManager.ENEMY_TAG) ||
    collision.CompareTag(TagManager.SHOOTER_ENEMY_TAG) ||
    collision.CompareTag(TagManager.BOSS_TAG))
    {
      SpawnExplosion();
      if (collision.TryGetComponent(out EnemyManager enemy))
      {
        enemy.Damage(bulletDamage);
        destroyObj = true;
      }
    }

    if (collision.CompareTag(TagManager.BLOCKING_TAG) || collision.CompareTag(TagManager.GATE))
    {
      SpawnExplosion();
      destroyObj = true;
    }
  }
  private void SpawnExplosion()
  {
    GameObject explosionEffect = Instantiate(playerWeaponManager.explosionEffect, gameObject.transform.position, playerWeaponManager.explosionEffect.transform.rotation);
    Destroy(explosionEffect, .5f);
  }
}
