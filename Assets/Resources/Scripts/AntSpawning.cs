using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class AntSpawning : MonoBehaviour {

    public GameObject antPrefab;
    public int dayLengthCountdown;
    public int antSpawnCountdown;
    public Vector2 antSpawnVector2;
    public bool areSpawning;

    private int dayLengthCountdownInner;
    private int dayNumber;
    private int colonyPopulationCounter;
    private int antSpawnCountdownInner;
    private GameObject tmpAnt;
    private ArrayList upperCaseLetters;
    private ArrayList lowerCaseLetters;
    private ArrayList nounList;
    private Text colonyPopulationText;
    private Text dayText;

	// Use this for initialization
	void Start () {
        antSpawnCountdownInner = antSpawnCountdown;
        nounList = new ArrayList();
        readTextFile("Assets/Resources/Files/nounList.txt");
        colonyPopulationText = GameObject.Find("ColonyPopulationText").GetComponent<Text>();
        dayText = GameObject.Find("DayText").GetComponent<Text>();
        colonyPopulationCounter = 0;
        areSpawning = true;
        dayNumber = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (antSpawnCountdownInner == 0 && areSpawning) { InstantiateAntPrefab(); }
        else if(areSpawning) { antSpawnCountdownInner--; }
        if (dayLengthCountdownInner == 0 && areSpawning) { FlipDay(); }
        else if (areSpawning) { dayLengthCountdownInner--; }
	}

    void InstantiateAntPrefab() {
        tmpAnt = Instantiate(antPrefab, antSpawnVector2, Quaternion.identity) as GameObject;
        tmpAnt.transform.parent = gameObject.transform;
        tmpAnt.name = RandomNameGenerator();
        tmpAnt.transform.FindChild("Head").GetComponent<Player>().dayBorn = dayNumber;
        colonyPopulationCounter++;
        colonyPopulationText.text = "Colony Population " + colonyPopulationCounter + ".";
        antSpawnCountdownInner = antSpawnCountdown;
    }

    string RandomNameGenerator() {
        string ret = nounList[Random.Range(0, nounList.Count)] as string;
        return char.ToUpper(ret[0]) + ret.Substring(1);
    }

    void readTextFile(string file_path) {
        StreamReader inp_stm = new StreamReader(file_path);
        while (!inp_stm.EndOfStream) { nounList.Add(inp_stm.ReadLine()); }
        inp_stm.Close();
        //Thanks Sam Ang!
    }

    void FlipDay() {
        dayNumber++;
        dayLengthCountdownInner = dayLengthCountdown;
        dayText.text = "Day " + dayNumber + ".";
    }
}
