using UnityEngine;

public class DoorController : MonoBehaviour
{

  public Animator doorAnimator;
  private AudioSource gateOpenSound;

  // Start is called before the first frame update
  void Awake()
  {
    gateOpenSound = GetComponent<AudioSource>();
  }



  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag(TagManager.PLAYER_TAG))
    {
      gateOpenSound.Play();
      doorAnimator.SetBool(TagManager.OPEN_ANIMATION_PARAMETER, true);
    }
  }
}
