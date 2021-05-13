using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
  [SerializeField] private AudioClip appleSE;
  [SerializeField] private AudioClip bombSE;
  private AudioSource audioSource;


  private void Start()
  {
    audioSource = GetComponent<AudioSource>();
  }

  private void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;

      if (Physics.Raycast(ray, out hit, Mathf.Infinity))
      {
        float x = Mathf.RoundToInt(hit.point.x);
        float z = Mathf.RoundToInt(hit.point.z);
        transform.position = new Vector3(x, 0, z);
      }
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Apple")
    {
      audioSource.PlayOneShot(appleSE);
    }
    else
    {
      audioSource.PlayOneShot(bombSE);
    }
    Destroy(other.gameObject);
  }
}
