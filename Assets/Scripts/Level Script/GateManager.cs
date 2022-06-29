using UnityEngine;

public class GateManager : MonoBehaviour
{
  public float gateId;


  public void OpenGate(float waveId)
  {
    if (waveId == gateId)
    {
      Destroy(gameObject);
    }
  }

  public float GetGateId()
  {
    return gateId;
  }
}
