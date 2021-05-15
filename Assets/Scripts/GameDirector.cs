using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
  float time = 30.0f;
  int point = 0;

  Text timerText;
  Text pointText;
  ItemGenerator itemGenerator;

  private void Start()
  {
    timerText = GameObject.Find("Time").GetComponent<Text>();
    pointText = GameObject.Find("Point").GetComponent<Text>();
    itemGenerator = GameObject.Find("ItemGenerator").GetComponent<ItemGenerator>();
  }

  private void Update()
  {
    time -= Time.deltaTime;

    if (20.0f <= time)
    {
      itemGenerator.SetParameters(1.0f, -0.03f, 0.2f);
    }
    else if (10.0f <= time)
    {
      itemGenerator.SetParameters(0.7f, -0.04f, 0.4f);
    }
    else if (5.0f <= time)
    {
      itemGenerator.SetParameters(0.4f, -0.06f, 0.6f);
    }
    else if (0.0f < time)
    {
      itemGenerator.SetParameters(0.5f, -0.05f, 0.3f);
    }
    else
    {
      itemGenerator.itemGenerate = false;
      time = 0;
    }

    UpdateTimeText();
  }

  private void UpdateTimeText()
  {
    timerText.text = time.ToString("F1");
  }

  private void UpdatePointText()
  {
    pointText.text = point.ToString() + " point";
  }

  public void AddPoint(int pointToAdd)
  {
    point += pointToAdd;
    UpdatePointText();
  }

  public void CutPointInHalf()
  {
    point /= 2;
    UpdatePointText();
  }
}
