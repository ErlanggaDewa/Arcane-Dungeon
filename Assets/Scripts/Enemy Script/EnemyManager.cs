using UnityEngine;

public class EnemyManager : MonoBehaviour
{
  private Animator enemyAnimator;
  // Start is called before the first frame update
  void Start()
  {
    enemyAnimator = gameObject.GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    Debug.Log("EnemyManager: OnTriggerEnter2D");
    enemyAnimator.SetBool("Death", true);
    Destroy(gameObject, .25f);
  }
}
