using UnityEngine;
using CodeMonkey.HealthSystemCM;

public class PlayerManager : MonoBehaviour, IGetHealthSystem
{
  public float healthNumber;
  public HealthSystem healthSystem;
  Animator playerAnimator;


  private void Awake()
  {

    healthSystem = new HealthSystem(healthNumber);
    healthSystem.OnDead += HealthSystem_OnDead;
    playerAnimator = gameObject.GetComponent<Animator>();
  }



  public void Damage(float enemyDamage)
  {
    healthSystem.Damage(enemyDamage);
  }

  private void HealthSystem_OnDead(object sender, System.EventArgs e)
  {
    playerAnimator.SetBool(TagManager.DEATH_ANIMATION_PARAMETER, true);
    Destroy(gameObject, .25f);
  }

  public HealthSystem GetHealthSystem()
  {
    return healthSystem;
  }


}
