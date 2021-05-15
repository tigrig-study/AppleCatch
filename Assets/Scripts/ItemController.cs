using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
  public float dropSpeed = -0.03f;

  private void Update()
  {
    transform.Translate(0, dropSpeed * 60 * Time.deltaTime, 0);
    if (transform.position.y <= -1.0f) Destroy(gameObject);
  }
}
