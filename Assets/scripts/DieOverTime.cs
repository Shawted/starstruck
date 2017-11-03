using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOverTime : MonoBehaviour {

  public float timeTillDie = 0;

  float timer = 0;

  // Update is called once per frame
  void Update()
  {
    timer += Time.deltaTime;

    if (timer >= timeTillDie)
    {
      Destroy(gameObject);
    }

  }
}
