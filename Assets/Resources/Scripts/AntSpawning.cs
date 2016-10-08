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
        //upperCaseLetters = new ArrayList {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
        //lowerCaseLetters = new ArrayList {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"};
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
        string ret = upperCaseLetters[Random.Range(0, upperCaseLetters.Count)] as string;
        while (Random.Range(0, 10) > 1) ret = string.Concat(ret, lowerCaseLetters[Random.Range(0, upperCaseLetters.Count)] as string);
        return ret;
    }
}
