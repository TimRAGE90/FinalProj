using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Trigger : MonoBehaviour
{
  public Platform_Moving platform;

  private void OnTriggerEnter(Collider other)
  {
      platform.NextPlatform();
  }
}
