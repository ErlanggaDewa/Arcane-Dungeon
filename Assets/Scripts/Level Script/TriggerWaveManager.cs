using UnityEngine;

public class TriggerWaveManager : MonoBehaviour
{
  public float waveId;
  GameObject[] gatesManager;
  GameObject[] enemies;
  AudioSource audioSource;


  void Start()
  {
    audioSource = gameObject.GetComponent<AudioSource>();
    gatesManager = GameObject.FindGameObjectsWithTag(TagManager.GATE);
    enemies = GameObject.FindGameObjectsWithTag(TagManager.ENEMY_TAG);
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag(TagManager.PLAYER_TAG))
    {
      ActivateSelectedGate();
      ActivateEnemy();
    }
  }

  private void ActivateEnemy()
  {
    foreach (GameObject enemy in enemies)
    {
      if (enemy.GetComponent<EnemyManager>().GetWaveId() == waveId)
      {
        enemy.GetComponent<EnemyMovement>().isCatchingPlayer = true;
        EnemyWeaponManager enemyWeaponManager = enemy.GetComponent<EnemyWeaponManager>();
        if (enemyWeaponManager)
        {
          enemyWeaponManager.isShooting = true;
        }
      }
    }

  }

  private void ActivateSelectedGate()
  {
    foreach (GameObject gate in gatesManager)
    {
      if (gate && gate.GetComponent<GateManager>().GetGateId() == waveId)
      {
        audioSource.Play();
        gate.GetComponent<GateManager>().OpenGate(waveId);
        Destroy(gameObject, .5f);
      }
    }
  }
}
