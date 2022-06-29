using UnityEngine;

public class EnemyWeaponManager : MonoBehaviour
{
  public GameObject enemyBullet;
  public float fireRate;
  float nextFire;
  EnemyMovement enemyMovement;
  public bool isShooting;

  void Start()
  {
    nextFire = Time.time;
    enemyMovement = GameObject.FindGameObjectWithTag(TagManager.ENEMY_TAG).GetComponent<EnemyMovement>();
  }
  void Update()
  {

    CheckIfTimeToFire();

  }

  void CheckIfTimeToFire()
  {
    if (Time.time > nextFire && isShooting)
    {
      Instantiate(enemyBullet, transform.position, Quaternion.identity);
      nextFire = Time.time + fireRate;
    }
  }

}
