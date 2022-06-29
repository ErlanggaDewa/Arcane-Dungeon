using UnityEngine;
using CodeMonkey.HealthSystemCM;

public class EnemyManager : MonoBehaviour, IGetHealthSystem
{
  private Animator enemyAnimator;
  public float healthNumber;
  private HealthSystem healthSystem;
  public float wave;



  private void Awake()
  {
    healthSystem = new HealthSystem(healthNumber);
    healthSystem.OnDead += HealthSystem_OnDead;
  }

  // Start is called before the first frame update
  void Start()
  {
    enemyAnimator = gameObject.GetComponent<Animator>();
  }


  private void OnTriggerEnter2D(Collider2D other)
  {

    if (other.gameObject.CompareTag(TagManager.PLAYER_TAG))
    {
      Debug.Log("Hit Player");
    }

  }

  public void Damage()
  {
    healthSystem.Damage(10);
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
