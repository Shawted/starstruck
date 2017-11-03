using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RhythmMaster : MonoBehaviour
{

	public class TickBlock
	{
		public List<NoteData> notes = new List<NoteData> ();
	}

	public static float TIME_MOD = 0;

  public float start_song_delay;

	public GameObject streakCounter = null;
  
	public Image Heart1 = null;
	public Image Heart2 = null;
	public Image Heart3 = null;

	// Set these in inspector
	public List<GameObject> columnAnchors = new List<GameObject> ();
	public List<GameObject> buttonAnchors = new List<GameObject> ();
	public float bpm = 60;

	public GameObject notePrefab = null;
	public GameObject tailPrefab = null;

  public float totalTicks = 0;

  public int points = 0;

	float lives = 3;
	public float streak = 0;
	float currtimer = 0;
	int ticks = -1;

	public Text ObjectiveText;

	//public PlayerPrefManager playerPrefManager;

	int hits = 0;
	//float ObjectiveTime;
	bool Objective1 = false;
	bool Objective2 = false;
	bool Objective3 = false;

	List<TickBlock> tickBlocks = new List<TickBlock> ();

	// Use this for initialization
	void Awake ()
	{
		TIME_MOD = (bpm * Time.deltaTime) / 60.0f;

		ReadInNoteSheet ();

		//playerPrefManager = GetComponent<PlayerPrefManager>();
	}

	void ReadInNoteSheet ()
	{
		TickBlock tick;

		//BLANK TICK
		tick = new TickBlock ();
		tickBlocks.Add (tick);

		//4TH ROW
		tick = new TickBlock ();
		tick.notes.Add (new NoteData (3, 0));
		tickBlocks.Add (tick);

		//BLANK TICK
		tick = new TickBlock ();
		tickBlocks.Add (tick);

		//3RD ROW
		tick = new TickBlock ();
		tick.notes.Add (new NoteData (2, 0));
		tickBlocks.Add (tick);

		//BLANK TICK
		tick = new TickBlock ();
		tickBlocks.Add (tick);

		//1ST ROW
		tick = new TickBlock ();
		tick.notes.Add (new NoteData (0, 0));
		tickBlocks.Add (tick);

		//BLANK TICK
		tick = new TickBlock ();
		tickBlocks.Add (tick);

		//2ND ROW
		tick = new TickBlock ();
		tick.notes.Add (new NoteData (1, 0));
		tickBlocks.Add (tick);

		//3RD ROW
		tick = new TickBlock ();
		tick.notes.Add (new NoteData (2, 0));
		tickBlocks.Add (tick);

		//1ST ROW
		tick = new TickBlock ();
		tick.notes.Add (new NoteData (0, 0));
		tickBlocks.Add (tick);

		//BLANK TICK
		tick = new TickBlock ();
		tickBlocks.Add (tick);

		//4TH ROW
		tick = new TickBlock ();
		tick.notes.Add (new NoteData (3, 0));
		tickBlocks.Add (tick);

		//BLANK TICK
		tick = new TickBlock ();
		tickBlocks.Add (tick);

		//3RD-2ND ROW
		tick = new TickBlock ();
		tick.notes.Add (new NoteData (2, 0));
		tick.notes.Add (new NoteData (3, 0));
		tickBlocks.Add (tick);

		//BLANK TICK
		tick = new TickBlock ();
		tickBlocks.Add (tick);

		//4TH ROW
		tick = new TickBlock ();
		tick.notes.Add (new NoteData (3, 0));
		tickBlocks.Add (tick);

		//1ST-4TH ROW
		tick = new TickBlock ();
		tick.notes.Add (new NoteData (0, 0));
		tick.notes.Add (new NoteData (3, 0));
		tickBlocks.Add (tick);

		//1ST-2ND ROW
		tick = new TickBlock ();
		tick.notes.Add (new NoteData (0, 0));
		tick.notes.Add (new NoteData (1, 0));
		tickBlocks.Add (tick);

		//BLANK TICK
		tick = new TickBlock ();
		tickBlocks.Add (tick);

		//3RD-4TH ROW
		tick = new TickBlock ();
		tick.notes.Add (new NoteData (2, 0));
		tick.notes.Add (new NoteData (3, 0));
		tickBlocks.Add (tick);


		//BLANK TICK
		tick = new TickBlock ();
		tickBlocks.Add (tick);

		//2ND-3RD ROW
		tick = new TickBlock ();
		tick.notes.Add (new NoteData (1, 0));
		tick.notes.Add (new NoteData (2, 0));
		tickBlocks.Add (tick);

		//42

		//BLANK TICK
		tick = new TickBlock ();
		tickBlocks.Add (tick);

		//2ND-3RD ROW
		tick = new TickBlock ();
		tick.notes.Add (new NoteData (3, 0));
		tick.notes.Add (new NoteData (0, 0.5f));
		tickBlocks.Add (tick);

		//3RD ROW
		tick = new TickBlock ();
		tick.notes.Add (new NoteData (2, 0));
		tickBlocks.Add (tick);

		//3RD ROW
		tick = new TickBlock ();
		tick.notes.Add (new NoteData (2, 0));
		tickBlocks.Add (tick);

		//1ST ROW
		tick = new TickBlock ();
		tick.notes.Add (new NoteData (0, 0));
		tickBlocks.Add (tick);

		//2ND ROW
		tick = new TickBlock ();
		tick.notes.Add (new NoteData (1, 0));
		tickBlocks.Add (tick);

		//54

		//4TH ROW
		tick = new TickBlock ();
		tick.notes.Add (new NoteData (3, 0));
		tickBlocks.Add (tick);

		//3RD ROW
		tick = new TickBlock ();
		tick.notes.Add (new NoteData (2, 0));
		tickBlocks.Add (tick);

    //4TH ROW
    tick = new TickBlock();
    tick.notes.Add(new NoteData(3, 0));
    tickBlocks.Add(tick);

    //3RD ROW
    tick = new TickBlock();
    tick.notes.Add(new NoteData(2, 0));
    tickBlocks.Add(tick);

    //2ND ROW
    tick = new TickBlock();
    tick.notes.Add(new NoteData(1, 0.5f));
    tickBlocks.Add(tick);

    //1st hold
    tick = new TickBlock();
    tick.notes.Add(new NoteData(0, 0, 3.5f));
    tickBlocks.Add(tick);


    //BLANK TICK
    tick = new TickBlock();
    tickBlocks.Add(tick);

    //BLANK TICK
    tick = new TickBlock();
    tickBlocks.Add(tick);

    //BLANK TICK
    tick = new TickBlock();
    tickBlocks.Add(tick);

    //24 hold
    tick = new TickBlock();
    tick.notes.Add(new NoteData(1, 0, 2.5f));
    tick.notes.Add(new NoteData(3, 0, 2.5f));
    tickBlocks.Add(tick);

    //BLANK TICK
    tick = new TickBlock();
    tickBlocks.Add(tick);

    //BLANK TICK
    tick = new TickBlock();
    tickBlocks.Add(tick);

    // Temp fill that in
  }

	void UpdateLives ()
	{
		if (lives == 2)
			Heart3.color = Color.red;
		if (lives == 1)
			Heart2.color = Color.red;
		if (lives == 0)
			Heart1.color = Color.red;
	}

	void MissedNote ()
	{
		//print ("miss");
		streak = 0;
		streakCounter.GetComponent<Text> ().text = "0";
		lives--;

		UpdateLives ();

		if (lives <= 0) {
			//Application.LoadLevel (Application.loadedLevel);

			//Send objectives and score to scoreManager
			//playerPrefManager.SaveToDisk("highScore", points);
			Application.LoadLevel("Menu");
		}
	}

	void HitNote (bool poor)
	{
		//print ("hit");
		if (!poor) {
			streak++;
			hits++;
		}	
		else
			streak = 0;
		// clear objective text from screen
		ObjectiveText.text = "";

		streakCounter.GetComponent<Text> ().text = streak.ToString ();

		if (streak == 20) {
			//objective 1: you got a streak of 20 stars!
			//
			ObjectiveText.text = "you got a streak of 20 stars!";
			Objective1 = true;
			//ObjectiveTime += Time.deltaTime;
			//Debug.Log(ObjectiveTime);
		}
		if (hits == 50) {
			//objective 2
			ObjectiveText.text = "you got 50 stars!";
			Objective2 = true;
			//ObjectiveTime += Time.deltaTime;
			//Debug.Log(ObjectiveTime);
		}
	}

	bool done = false;
  float cur_delay_time = 0;
	// Update is called once per frame
	void Update ()
	{
    if(cur_delay_time >= 0)
      cur_delay_time += (bpm * Time.deltaTime) / 60.0f;

    if(cur_delay_time >= start_song_delay)
    {
      cur_delay_time = -1;
      Camera.main.GetComponent<AudioSource>().Play();
    }

    currtimer += (bpm * Time.deltaTime) / 60.0f;

		if (currtimer >= 1) {
			currtimer = 0;
			++ticks;
		}

		if (tickBlocks.Count <= ticks)
			done = true;

		if (done)
			return;

    if (ticks == -1) return;

    foreach (var note in tickBlocks[ticks].notes) {
      if (currtimer >= note.offset) {
        SpawnNote(note);
      }
    }

    if(ticks >= totalTicks)
      Application.LoadLevel("Menu");
  }

	void SpawnNote (NoteData note)
	{
		if (note.spawned)
			return;
    
		note.spawned = true;

		var noted = Instantiate (notePrefab, columnAnchors [note.column].transform.position, new Quaternion ());

		noted.transform.parent = columnAnchors [note.column].transform.parent;

		noted.GetComponent<Note> ().rhythmMaster = this;
		noted.GetComponent<Note> ().data = note;
		noted.GetComponent<Note> ().Startup ();
    
		if (note.length > 0) {
			float offset = ((note.length * 60.0f) / bpm) * (TIME_MOD * 100);

			var tail = Instantiate (tailPrefab, noted.transform.position + new Vector3 (0, offset / 2, 0), new Quaternion ());

			tail.transform.localScale = new Vector3 (tail.transform.localScale.x, tail.transform.localScale.y * offset, tail.transform.localScale.z);

			tail.transform.parent = noted.transform;
		}
	}

	void SpawnLongNote (NoteData note)
	{
		//Place object in slot. 
		//Draw all the way to the end.
		//Calculate distance based on BPM
	}
}
