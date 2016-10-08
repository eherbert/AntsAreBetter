using UnityEngine;
using System.Collections;

public class AntSpawning : MonoBehaviour {

    public GameObject antPrefab;
    public int antSpawnCountdown;
    public Vector2 antSpawnVector2;

    private int antSpawnCountdownInner;
    private GameObject tmpAnt;
    private ArrayList upperCaseLetters;
    private ArrayList lowerCaseLetters;

	// Use this for initialization
	void Start () {
        antSpawnCountdownInner = antSpawnCountdown;
        upperCaseLetters = new ArrayList {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
        lowerCaseLetters = new ArrayList {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"};
	}
	
	// Update is called once per frame
	void Update () {
	    if(antSpawnCountdownInner==0) {
            tmpAnt = Instantiate(antPrefab, antSpawnVector2, Quaternion.identity) as GameObject;
            tmpAnt.transform.parent = gameObject.transform;
            tmpAnt.name = RandomNameGenerator();
            antSpawnCountdownInner = antSpawnCountdown;
        } else {
            antSpawnCountdownInner--;
        }
	}

    string RandomNameGenerator() {
        string ret = upperCaseLetters[Random.Range(0, upperCaseLetters.Count)] as string;
        while (Random.Range(0, 10) > 1) ret = string.Concat(ret, lowerCaseLetters[Random.Range(0, upperCaseLetters.Count)] as string);
        return ret;
    }
}
