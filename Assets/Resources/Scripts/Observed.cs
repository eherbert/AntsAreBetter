using UnityEngine;
using System.Collections;

public class Observed : MonoBehaviour {

    private ArrayList ants;
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
    public void Register(Vector2 tmp, string s) {
        switch(s) {
            case "goodItems": {
                    goodItems.Add(tmp);
                    NotifyAllAnts(tmp, s);
                }
                break;
            case "badItems": {
                    badItems.Add(tmp);
                    NotifyAllAnts(tmp, s);
                }
                break;
        }
    }

    public void Deregister(GameObject tmp) { ants.Remove(tmp); }

    public void Notify(GameObject tmp, string message, string info) {
        queen.GetComponent<AntSpawning>().OnNotify(tmp, message, info);
    }
    
    public void NotifyAllAnts(Vector2 tmp, string message) {
        foreach(GameObject ant in ants) {

        }
    }
}
