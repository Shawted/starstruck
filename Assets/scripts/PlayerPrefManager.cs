using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefManager : MonoBehaviour {
	//http://answers.unity3d.com/questions/1034532/making-a-less-complicated-save-system.html
	static PlayerPrefManager instance;// singeton - keeping one Manager between many scenes

	public bool objective1 = false;
	public bool objective2 = false;

	public int unlockedLevels;
	public int highScore;

	public GameObject menu;



	void Awake() {
		

		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		LoadFromDisk ("unlockedLevels");

	}

	void OnEnable(){
		unlockedLevels = PlayerPrefs.GetInt ("unlockedLevels");
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.T)) {
			//scoreSave ();
			//unlockedLevels = null;
		}
	}


	void SaveToDisk(string key, int value){
		PlayerPrefs.SetInt(key, value);
		//PlayerPrefs.Save(); //Writes all modified preferences to disk.
		Debug.Log ("saved _" + key + "= " + value);
	}
	int LoadFromDisk(string key){
		//PlayerPrefs.;
		if (PlayerPrefs.HasKey (key)) {
			Debug.Log ("loaded _" + key + "= " + PlayerPrefs.GetInt (key));
			return PlayerPrefs.GetInt (key);
		} 
		else {
			return -1;
//			Debug.Log ("No playerPrefs");
//			if (key == null) {
//				key = 0;
//			}
		}
	}

	void ShowMenuItems(){
//		if (!PlayerPrefs.HasKey("stage1_beat"))
//		{
//			PlayerPrefs.SetInt("stage1_beat", debug);
//		}
//		menu.SetActive(true);
	}

	void UnlockNextLevel(){
		Debug.Log ("unlockedLevels _" + unlockedLevels);
		unlockedLevels = LoadFromDisk ("unlockedLevels");// get
		unlockedLevels++;
		SaveToDisk ("unlockedLevels",unlockedLevels);


	}

} 