using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteData
{
  public NoteData(int column, float offset, float length = 0)
  {
    this.column = column;
    this.offset = offset;
    this.length = length;
  }

  public int column;

  public float offset = 0;

  public bool spawned = false;

  public float length = 0;
}

public class Note : MonoBehaviour
{
  public RhythmMaster rhythmMaster;

  public NoteData data;

  bool added = false;
  
  public void Startup()
  {

  }
	
	// Update is called once per frame
	void Update ()
  {
    // TODO: Move the note
    transform.localPosition += new Vector3(0, -(RhythmMaster.TIME_MOD * 100), 0);

    // If we are adding this to the threshold
    if (!added && (gameObject.transform.localPosition.y - rhythmMaster.buttonAnchors[data.column].transform.localPosition.y < 
                   rhythmMaster.buttonAnchors[data.column].GetComponent<ButtonScanner>().poorThreshold))
    {
      //GetComponent<SpriteRenderer>().color = Color.blue;
      rhythmMaster.buttonAnchors[data.column].GetComponent<ButtonScanner>().AddToThreshold(gameObject);
      added = true;
    }
	}
}
