using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class AntSpawning : MonoBehaviour {

    public GameObject antPrefab;
    public int antSpawnCountdown;
    public Vector2 antSpawnVector2;

    private int antSpawnCountdownInner;
    private GameObject tmpAnt;
    private ArrayList upperCaseLetters;
    private ArrayList lowerCaseLetters;
    private ArrayList nounList;
    private Text colonyPopulationText;
    private int colonyPopulationCounter;

	// Use this for initialization
	void Start () {
        antSpawnCountdownInner = antSpawnCountdown;
        nounList = new ArrayList();
        readTextFile("Assets/Resources/Files/nounList.txt");
        colonyPopulationText = GameObject.Find("ColonyPopulationText").GetComponent<Text>();
        colonyPopulationCounter = 0;
    }
	
	// Update is called once per frame
	void Update () {
	    if(antSpawnCountdownInner==0) { InstantiateAntPrefab(); }
        else { antSpawnCountdownInner--; }
	}

    void InstantiateAntPrefab() {
        tmpAnt = Instantiate(antPrefab, antSpawnVector2, Quaternion.identity) as GameObject;
        tmpAnt.transform.parent = gameObject.transform;
        tmpAnt.name = RandomNameGenerator();
        colonyPopulationCounter++;
        colonyPopulationText.text = "Colony Population = " + colonyPopulationCounter;
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
    }
}
