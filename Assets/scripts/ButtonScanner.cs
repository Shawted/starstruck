using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScanner : MonoBehaviour {

  enum Quality
  {
    Missclick,
    Poor,
    Good,
    Great,
    Perfect
  }

  public RhythmMaster rhythmMaster;

  List<GameObject> touchingObjects = new List<GameObject>();

  public float poorThreshold;
  public float goodThreshold;
  public float greatThreshold;
  public float perfectThreshold;

  GameObject currHoldBurn;
  GameObject holding;
  float timeLeft;
  
  //Particles
  public GameObject success;
  public GameObject holdBurn;
  public GameObject fail;

  public Text status;

  public void AddToThreshold(GameObject note)
  {
    touchingObjects.Add(note);
  }

  void Missed()
  {

  }

	// Use this for initialization
	void Start ()
  {
		
	}

  int determinePointGain(Quality quality)
  {
		int pointsGained = 0;

    if (quality == Quality.Poor)
    {
      pointsGained = 5;
    }
    else if (quality == Quality.Good)
    {
      pointsGained = 25;
    }
    else if (quality == Quality.Great)
    {
      pointsGained = 100;
    }
    else if (quality == Quality.Perfect)
    {
      pointsGained = 250;
    }

    // Point multiplier 
    if (rhythmMaster.streak > 100)
    {
      pointsGained *= 5;
    }
    else if(rhythmMaster.streak > 40)
    {
      pointsGained *= 4;
    }
    else if (rhythmMaster.streak > 20)
    {
      pointsGained *= 3;

    }
    else if (rhythmMaster.streak > 10)
    {
      pointsGained *= 2;
    }
    return pointsGained;
  }

  Quality DetermineQuality(Vector3 position)
  {
    float dist = Mathf.Abs(position.y - gameObject.transform.localPosition.y);

    if (dist < perfectThreshold)
    {
      rhythmMaster.points += 50;
      return Quality.Perfect;
    }
    if (dist < greatThreshold)
    {
      rhythmMaster.points += 50;
      return Quality.Great;
    }
    if (dist < goodThreshold)
    {
      rhythmMaster.points += 50;
      return Quality.Good;
    }

    rhythmMaster.points += 50;
    return Quality.Poor;
  }

  public void Release()
  {
    if (currHoldBurn != null)
    {
      Destroy(currHoldBurn);
    }

    if(holding != null)
    {
      holding.GetComponent<SpriteRenderer>().color = new Color(.1f, .1f, .1f, .1f);
      holding.transform.Find("Tail(Clone)").GetComponent<SpriteRenderer>().color = new Color(.1f, .1f, .1f, .1f);

      holding = null;
    }
  }

  //TODO: Add long note support
  public void Click()
  {
    Quality quality;

    print(touchingObjects.Count);

    if (touchingObjects.Count > 0)
    {
      Instantiate(success, gameObject.transform.position, new Quaternion());

      print("GOTEM");
      quality = DetermineQuality(touchingObjects[0].transform.localPosition);

      if (touchingObjects[0].GetComponent<Note>().data.length > 0)
      {
        currHoldBurn = Instantiate(holdBurn, gameObject.transform.position, new Quaternion());
        holding = touchingObjects[0];
        touchingObjects.Remove(touchingObjects[0]);
      }
      else
      {
        touchingObjects[0].GetComponent<SpriteRenderer>().color = new Color(.1f,.1f,.1f,.1f);
        touchingObjects.Remove(touchingObjects[0]);
      }

      GetComponent<AudioSource>().Play();

      if(quality == Quality.Poor)
        rhythmMaster.SendMessage("HitNote", true);
      else
        rhythmMaster.SendMessage("HitNote", false);
    }
    else
    {
      Instantiate(fail, gameObject.transform.position, new Quaternion());

      quality = Quality.Missclick;

      rhythmMaster.SendMessage("MissedNote");
    }

    rhythmMaster.points += determinePointGain(quality);
    DisplayMessage(quality.ToString(), Color.white);
  }

  static float textTime = 0f;
  void DisplayMessage(string quality, Color color)
  {
    textTime = 0.4f;
    status.text = quality;
    status.color = color;

    //Display stuff later
    //print(quality);
  }

  List<GameObject> missed = new List<GameObject>();
	
	// Update is called once per frame
	void Update ()
  {
    textTime -= Time.deltaTime / 4;
    if(textTime <= 0)
    {
      status.color = Color.clear;
    }


    if (holding != null)
    {
      timeLeft += RhythmMaster.TIME_MOD;

      if(timeLeft >= holding.GetComponent<Note>().data.length)
      {
        Release();
      }
    }

		foreach(var note in touchingObjects)
    {
      if(note.transform.localPosition.y - gameObject.transform.localPosition.y < (-1 * poorThreshold))
      {
        missed.Add(note);
      }
    }

    //Purge all marked notes
    while (missed.Count > 0)
    {
      touchingObjects[0].GetComponent<SpriteRenderer>().color = new Color(.1f, .1f, .1f, .1f);

      if(touchingObjects[0].transform.Find("Tail(Clone)") != null)
        touchingObjects[0].transform.Find("Tail(Clone)").GetComponent<SpriteRenderer>().color = new Color(.1f, .1f, .1f, .1f);

      touchingObjects.Remove(missed[0]);
      missed.Remove(missed[0]); 
      rhythmMaster.SendMessage("MissedNote");

      DisplayMessage("Missed!", Color.gray);
    }
	}
}
