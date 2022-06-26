using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
  [SerializeField]
  private WeaponManager[] playerWeapons;

  private int weaponIndex;

  [SerializeField]
  private GameObject[] weaponBullets;

  public GameObject muzzleFlash;

  private Vector2 targetPos;
  private Vector2 direction;
  private Camera mainCam;
  private Vector2 bulletSpawnPosition;
  private Quaternion bulletRotation;

  private AudioSource playerAudio;




  private void Awake()
  {
    weaponIndex = 0;
    playerWeapons[weaponIndex].gameObject.SetActive(true);
    mainCam = Camera.main;

    playerAudio = GetComponent<AudioSource>();

  }

  private void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
    ChangeWeapon();
  }

  //  Set face of the gun to the direction of the mouse
  public void ActivateGun(int gunIndex)
  {
    playerWeapons[weaponIndex].ActivateGun(gunIndex);
  }

  void ChangeWeapon()
  {
    if (Input.GetKeyDown(KeyCode.Q))
    {
      playerWeapons[weaponIndex].gameObject.SetActive(false);
      weaponIndex++;
      if (weaponIndex == playerWeapons.Length)
        weaponIndex = 0;
      playerWeapons[weaponIndex].gameObject.SetActive(true);
    }
  }

  public void Shoot(Vector3 spawnPos)
  {
    targetPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
    bulletSpawnPosition = new Vector2(spawnPos.x, spawnPos.y);

    direction = (targetPos - bulletSpawnPosition).normalized;

    //  generate rotation angle of bullet
    bulletRotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);

    playerAudio.Play();

    GameObject newBullet = Instantiate(weaponBullets[weaponIndex], spawnPos, bulletRotation);
    newBullet.GetComponent<Bullet>().MoveInDirection(direction);
  }
}
