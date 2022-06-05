using UnityEngine;

public class WeaponManager : MonoBehaviour
{
  [SerializeField]
  private GameObject[] guns;
  private int currentGun;

  // Start is called before the first frame update
  void Start()
  {
    DeactivateAllWeapons();
  }

  void DeactivateAllWeapons()
  {
    for (int i = 0; i < guns.Length; i++)
      guns[i].SetActive(false);
  }

  public void ActivateGun(int newGunIndex)
  {
    guns[currentGun].SetActive(false);
    guns[newGunIndex].SetActive(true);
    currentGun = newGunIndex;
  }
}
