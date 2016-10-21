using UnityEngine;
using System.Collections;

public class Observed : MonoBehaviour {

    private ArrayList ants;
    /*private ArrayList whiteAnts;
    private ArrayList redAnts;
    private ArrayList orangeAnts;
    private ArrayList yellowAnts;
    private ArrayList greenAnts;
    private ArrayList blueAnts;
    private ArrayList violetAnts;
    private ArrayList blackAnts;*/

    private ArrayList goodItems;
    private ArrayList badItems;
    private GameObject queen;

    void Awake()
    {
        ants = new ArrayList();
        goodItems = new ArrayList();
        queen = GameObject.Find("Queen");
    }
    
    public void Register(GameObject tmp) { ants.Add(tmp); }
    public void Register(GameObject tmp, string message, string info) {
        switch(message) {
            case "goodItems": {
                    if(!goodItems.Contains(tmp)) goodItems.Add(tmp);
                    NotifyAllAnts(tmp, message, info);
                }
                break;
            case "badItems": {
                    if(!badItems.Contains(tmp)) badItems.Add(tmp);
                    NotifyAllAnts(tmp, message, info);
                }
                break;
        }
    }

    public void Deregister(GameObject tmp,string message,string info) {
        switch(message) {
            case "goodItems":
                NotifyAllAntsDeregister(tmp, message, info);
                goodItems.Remove(tmp);
                break;
            case "badItems":
                NotifyAllAntsDeregister(tmp, message, info);
                badItems.Remove(tmp);
                break;
        }
    }

    public void Notify(GameObject tmp, string message, string info) {
        queen.GetComponent<AntSpawning>().OnNotify(tmp, message, info);
    }
    
    public void NotifyAllAnts(GameObject tmp, string message, string info) {
        foreach(GameObject ant in ants) {
            ant.transform.FindChild("Head").GetComponent<Player>().OnNotify(tmp, message, info);
        }
    }
    public void NotifyAllAntsDeregister(GameObject tmp, string message, string info) {
        foreach (GameObject ant in ants) {
            ant.transform.FindChild("Head").GetComponent<Player>().OnNotifyDeregister(tmp, message, info);
        }
    }
}
