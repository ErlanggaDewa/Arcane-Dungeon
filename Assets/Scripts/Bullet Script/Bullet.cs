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

      destroyObj = true;
    }

    if (collision.CompareTag(TagManager.BLOCKING_TAG))
    {
      SpawnExplosion();

      destroyObj = true;
    }
  }
  private void SpawnExplosion()
  {


    GameObject muzzleSpawn = Instantiate(playerWeaponManager.muzzleFlash, gameObject.transform.position, playerWeaponManager.muzzleFlash.transform.rotation);
    Destroy(muzzleSpawn, .5f);
  }
}
