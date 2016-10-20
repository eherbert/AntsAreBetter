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
    public GameObject repo;

    private int dayLengthCountdownInner;
    private int dayNumber;
    private int colonyPopulationCounter;
    private int antSpawnCountdownInner;
    private GameObject tmpAnt;
    private string[] nounList;
    private Text colonyPopulationText;
    private Text dayText;
    private Color currentColor;
    private string currentColorText;
    private bool isSpawningWithTrailRenderer;

	// Use this for initialization
	void Start () {
        antSpawnCountdownInner = antSpawnCountdown;
        nounList = new string[0];
        readTextFile("Files/Text/nounList");
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
        SetTraits();
        RegisterToRepo();
        UpdateColonyPopulationText();
        antSpawnCountdownInner = antSpawnCountdown;
    }

    void SetTraits() {
        tmpAnt.name = RandomNameGenerator();
        tmpAnt.transform.FindChild("Head").GetComponent<SpriteRenderer>().color = currentColor;
        tmpAnt.transform.FindChild("Thorax").GetComponent<SpriteRenderer>().color = currentColor;
        tmpAnt.transform.FindChild("Abdomen").GetComponent<SpriteRenderer>().color = currentColor;
        tmpAnt.transform.FindChild("Head").GetComponent<Player>().SetDayBorn(dayNumber);
        tmpAnt.transform.FindChild("Abdomen").GetComponent<TrailRenderer>().enabled = isSpawningWithTrailRenderer;
        tmpAnt.transform.FindChild("Head").GetComponent<Player>().SetCurrentColorText(currentColorText);
    }

    void RegisterToRepo() {
        repo.GetComponent<Observed>().Register(tmpAnt);
    }

    string RandomNameGenerator() {
        string ret = nounList[Random.Range(0, nounList.Length)] as string;
        return char.ToUpper(ret[0]) + ret.Substring(1);
    }

    void readTextFile(string file_path) {
        TextAsset t = Resources.Load(file_path) as TextAsset;
        nounList = t.text.Split('\n');
        /*StreamReader inp_stm = new StreamReader(file_path);
        while (!inp_stm.EndOfStream) { nounList.Add(inp_stm.ReadLine()); }
        inp_stm.Close();*/
        //Thanks Sam Ang!
    }

    void UpdateColonyPopulationText() {
        colonyPopulationCounter++;
        colonyPopulationText.text = "Colony Population " + colonyPopulationCounter + ".";
    }

    void FlipDay() {
        dayNumber++;
        dayLengthCountdownInner = dayLengthCountdown;
        dayText.text = "Day " + dayNumber + ".";
    }

    public void SetCurrentColor(string color) {
        switch(color)
        {
            case "white":
                currentColor = Color.white;
                gameObject.transform.FindChild("Head").GetComponent<SpriteRenderer>().color = currentColor;
                gameObject.transform.FindChild("Thorax").GetComponent<SpriteRenderer>().color = currentColor;
                gameObject.transform.FindChild("Abdomen").GetComponent<SpriteRenderer>().color = currentColor;
                break;
            case "red":
                currentColor = Color.red;
                gameObject.transform.FindChild("Head").GetComponent<SpriteRenderer>().color = currentColor;
                gameObject.transform.FindChild("Thorax").GetComponent<SpriteRenderer>().color = currentColor;
                gameObject.transform.FindChild("Abdomen").GetComponent<SpriteRenderer>().color = currentColor;
                break;
            case "yellow":
                currentColor = Color.yellow;
                gameObject.transform.FindChild("Head").GetComponent<SpriteRenderer>().color = currentColor;
                gameObject.transform.FindChild("Thorax").GetComponent<SpriteRenderer>().color = currentColor;
                gameObject.transform.FindChild("Abdomen").GetComponent<SpriteRenderer>().color = currentColor;
                break;
            case "orange":
                currentColor = new Color(1.0f, 0.5f, 0.0f);
                gameObject.transform.FindChild("Head").GetComponent<SpriteRenderer>().color = currentColor;
                gameObject.transform.FindChild("Thorax").GetComponent<SpriteRenderer>().color = currentColor;
                gameObject.transform.FindChild("Abdomen").GetComponent<SpriteRenderer>().color = currentColor;
                break;
            case "green":
                currentColor = Color.green;
                gameObject.transform.FindChild("Head").GetComponent<SpriteRenderer>().color = currentColor;
                gameObject.transform.FindChild("Thorax").GetComponent<SpriteRenderer>().color = currentColor;
                gameObject.transform.FindChild("Abdomen").GetComponent<SpriteRenderer>().color = currentColor;
                break;
            case "blue":
                currentColor = Color.blue;
                gameObject.transform.FindChild("Head").GetComponent<SpriteRenderer>().color = currentColor;
                gameObject.transform.FindChild("Thorax").GetComponent<SpriteRenderer>().color = currentColor;
                gameObject.transform.FindChild("Abdomen").GetComponent<SpriteRenderer>().color = currentColor;
                break;
            case "violet":
                currentColor = new Color(0.4f, 0.0f, 1.0f);
                gameObject.transform.FindChild("Head").GetComponent<SpriteRenderer>().color = currentColor;
                gameObject.transform.FindChild("Thorax").GetComponent<SpriteRenderer>().color = currentColor;
                gameObject.transform.FindChild("Abdomen").GetComponent<SpriteRenderer>().color = currentColor;
                break;
            case "black":
                currentColor = Color.black;
                gameObject.transform.FindChild("Head").GetComponent<SpriteRenderer>().color = currentColor;
                gameObject.transform.FindChild("Thorax").GetComponent<SpriteRenderer>().color = currentColor;
                gameObject.transform.FindChild("Abdomen").GetComponent<SpriteRenderer>().color = currentColor;
                break;
        }
        currentColorText = color;
    }

    override public void OnNotify(GameObject observed, string message, string info)
    {
        switch (message)
        {
            case "color":
                SetCurrentColor(info);
                break;
            case "trail":
                if (info == "on") isSpawningWithTrailRenderer = true;
                else isSpawningWithTrailRenderer = false;
                break;
        }
    }
}
