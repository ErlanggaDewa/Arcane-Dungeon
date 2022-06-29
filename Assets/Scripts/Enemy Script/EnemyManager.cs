using UnityEngine;
using CodeMonkey.HealthSystemCM;

public class EnemyManager : MonoBehaviour, IGetHealthSystem
{
  private Animator enemyAnimator;
  public float healthNumber;
  private HealthSystem healthSystem;
  public float wave;
  public float enemyDamage;



  private void Awake()
  {
    healthSystem = new HealthSystem(healthNumber);
    healthSystem.OnDead += HealthSystem_OnDead;
  }

  void Start()
  {
    enemyAnimator = gameObject.GetComponent<Animator>();
  }


  private void OnTriggerEnter2D(Collider2D other)
  {

    if (other.gameObject.CompareTag(TagManager.PLAYER_TAG))
    {
      if (other.TryGetComponent(out PlayerManager player))
      {
        player.Damage(enemyDamage);
      }
    }

  }

  public void Damage(float playerDamage)
  {
    healthSystem.Damage(playerDamage);
  }

  private void HealthSystem_OnDead(object sender, System.EventArgs e)
  {
    enemyAnimator.SetBool(TagManager.DEATH_ANIMATION_PARAMETER, true);
    Destroy(gameObject, .25f);

  }

  public HealthSystem GetHealthSystem()
  {
    return healthSystem;
  }

  public float GetWaveId()
  {
    return wave;
  }
}
