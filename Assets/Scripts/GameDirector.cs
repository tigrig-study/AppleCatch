using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
  float time = 60.0f;
  int point = 0;

  Text timerText;
  Text pointText;

  private void Start()
  {
    timerText = GameObject.Find("Time").GetComponent<Text>();
    pointText = GameObject.Find("Point").GetComponent<Text>();
  }

  private void Update()
  {
    time -= Time.deltaTime;
    timerText.text = time.ToString("F1");
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

  private void UpdatePointText()
  {
    pointText.text = point.ToString() + " point";
  }
}
