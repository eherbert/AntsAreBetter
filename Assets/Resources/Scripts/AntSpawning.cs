using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class AntSpawning : Observer {

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
    private Color currentColor;

	// Use this for initialization
	void Start () {
        antSpawnCountdownInner = antSpawnCountdown;
        nounList = new ArrayList();
        readTextFile("Assets/Resources/Files/Text/nounList.txt");
        colonyPopulationText = GameObject.Find("ColonyPopulationText").GetComponent<Text>();
        dayText = GameObject.Find("DayText").GetComponent<Text>();
        colonyPopulationCounter = 0;
        areSpawning = true;
        dayNumber = 0;
        currentColor = Color.white;
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
        tmpAnt.transform.FindChild("Head").GetComponent<SpriteRenderer>().color = currentColor;
        tmpAnt.transform.FindChild("Thorax").GetComponent<SpriteRenderer>().color = currentColor;
        tmpAnt.transform.FindChild("Abdomen").GetComponent<SpriteRenderer>().color = currentColor;
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

    public void SetCurrentColor(string color) {
        switch(color)
        {
            case "white": currentColor = Color.white;
                break;
            case "red": currentColor = Color.red;
                break;
            case "yellow": currentColor = Color.yellow;
                break;
            case "orange": currentColor = Color.cyan;
                break;
            case "green": currentColor = Color.green;
                break;
            case "blue": currentColor = Color.blue;
                break;
            case "purple": currentColor = Color.cyan;
                break;
            case "black": currentColor = Color.black;
                break;
        }
    }

    override public void OnNotify(GameObject observed, string message, string info)
    {
        switch (message)
        {
            case "color":
                SetCurrentColor(info);
                break;
        }
    }
}
