using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
  [SerializeField] GameObject applePrefab;
  [SerializeField] GameObject bombPrefab;

  float delta = 0;

  float span = 1.0f;
  float speed = -0.03f;
  float bombRatio = 0.2f;

  public bool itemGenerate = true;

  public void SetParameters(float span, float speed, float bombRatio)
  {
    this.span = span;
    this.speed = speed;
    this.bombRatio = bombRatio;
  }

  private void Update()
  {
    if (!itemGenerate) return;

    delta += Time.deltaTime;

    if (delta > this.span)
    {
      delta = 0;
      GameObject item;
      if (bombRatio > Random.Range(0f, 1f))
      {
        item = Instantiate(bombPrefab);
      }
      else
      {
        item = Instantiate(applePrefab);
      }
      int x = Random.Range(-1, 2);
      int z = Random.Range(-1, 2);
      item.transform.position = new Vector3(x, 4, z);
      item.GetComponent<ItemController>().dropSpeed = speed;
    }
  }
}
