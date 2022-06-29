using UnityEngine;

public class PlayerShootingManager : MonoBehaviour
{
  [SerializeField]
  public static float shootingTimerLimit;
  private float shootingTimer;

  [SerializeField]
  private Transform bulletSpawnPos;

  private PlayerWeaponManager playerWeaponManager;


  private void Awake()
  {
    shootingTimerLimit = .3f;
    playerWeaponManager = GetComponent<PlayerWeaponManager>();

  }

  private void Update()
  {
    HandleShooting();
  }
  void HandleShooting()
  {
    if (Input.GetMouseButton(0))
      if (Time.time > shootingTimer)
      {
        shootingTimer = Time.time + shootingTimerLimit;

        // Animate muzzle flash
        CreateBullet();
      }
  }

  void CreateBullet()
  {
    playerWeaponManager.Shoot(bulletSpawnPos.position);
  }
}
