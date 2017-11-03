using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    public GameObject stageSelect;
    public GameObject stage2;
    public GameObject stage2num;
    public GameObject stage2gray;
    public GameObject stage2graynum;
    public GameObject currentUI;
    public GameObject title;
    public GameObject singleMulti;
    public GameObject endless1;
    public GameObject endless1Gray;
    public GameObject endless2;
    public GameObject endless2Gray;
    public GameObject coopDuel;
    public GameObject endlessCampaign1;
    public GameObject endlessCampaign2;
    public GameObject stage3;
    public GameObject stage3num;
    public GameObject stage3gray;
    public GameObject stage3graynum;
    public GameObject endless3;
    public GameObject endless3Gray;
    public GameObject endlessCampaign3;
    public int DEBUG_FLAG;

    [SerializeField] public Dictionary<GameObject, GameObject> uiParents = new Dictionary<GameObject, GameObject>();

    public static bool endlessMode;

    public GameObject[] menuUIDialogs;
	// Use this for initialization
	void Start () {
        InitPrefs(DEBUG_FLAG);
        InitParents();
        bool stage1_beat = PlayerPrefs.GetInt("stage1_beat") == 1;
        bool stage2_beat = PlayerPrefs.GetInt("stage2_beat") == 1;
        bool stage3_beat = PlayerPrefs.GetInt("stage3_beat") == 1;
        print(stage1_beat +" "+ stage2_beat);
        stage2.GetComponent<Renderer>().enabled = (stage1_beat);
        stage2.GetComponent<BoxCollider>().enabled = (stage1_beat);
        stage2num.GetComponent<Renderer>().enabled = (stage1_beat);
        stage2gray.GetComponent<Renderer>().enabled = (!stage1_beat);
        stage2graynum.GetComponent<Renderer>().enabled = (!stage1_beat);
        endless1.GetComponent<Renderer>().enabled = (stage1_beat);
        endless1.GetComponent<BoxCollider>().enabled = (stage1_beat);
        endless1Gray.GetComponent<Renderer>().enabled = (!stage1_beat);
        endless2.GetComponent<Renderer>().enabled = (stage2_beat);
        endless2.GetComponent<BoxCollider>().enabled = (stage2_beat);
        endless2Gray.GetComponent<Renderer>().enabled = (!stage2_beat);
        endless3.GetComponent<Renderer>().enabled = (stage3_beat);
        endless3.GetComponent<BoxCollider>().enabled = (stage3_beat);
        endless3Gray.GetComponent<Renderer>().enabled = (!stage3_beat);
        stage3.GetComponent<Renderer>().enabled = (stage2_beat);
        stage3.GetComponent<BoxCollider>().enabled = (stage2_beat);
        stage3num.GetComponent<Renderer>().enabled = (stage2_beat);
        stage3gray.GetComponent<Renderer>().enabled = (!stage2_beat);
        stage3graynum.GetComponent<Renderer>().enabled = (!stage2_beat);
    }

    void InitParents()
    {
        // key - child, value - parent
        uiParents.Add(stageSelect, singleMulti);
        uiParents.Add(endlessCampaign1, stageSelect);
        uiParents.Add(endlessCampaign2, stageSelect);
        uiParents.Add(endlessCampaign3, stageSelect);
        uiParents.Add(singleMulti, title);
        uiParents.Add(coopDuel, singleMulti);
    }
	
	public void goBackUI()
    {
        print("GOING BACK UI");
        currentUI.SetActive(false);
        //currentUI--;
        currentUI = uiParents[currentUI];
        currentUI.SetActive(true);
    }

    void InitPrefs(int debug = 0)
    {
        if (!PlayerPrefs.HasKey("stage1_beat"))
        {
            PlayerPrefs.SetInt("stage1_beat", debug);
        }
        if (!PlayerPrefs.HasKey("stage2_beat"))
        {
            PlayerPrefs.SetInt("stage2_beat", debug);
        }
        if (!PlayerPrefs.HasKey("stage3_beat"))
        {
            PlayerPrefs.SetInt("stage3_beat", debug);
        }
        if (!PlayerPrefs.HasKey("stage1_endless_score"))
        {
            PlayerPrefs.SetInt("stage1_endless_score", debug);
        }
        if (!PlayerPrefs.HasKey("stage2_endless_score"))
        {
            PlayerPrefs.SetInt("stage2_endless_score", debug);
        }
        if (!PlayerPrefs.HasKey("stage3_endless_score"))
        {
            PlayerPrefs.SetInt("stage3_endless_score", debug);
        }
    }
}
