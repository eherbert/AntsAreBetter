using UnityEngine;
using System.Collections;

public class Observed : MonoBehaviour {

    private ArrayList ants;
    private GameObject queen;

    void Awake()
    {
        ants = new ArrayList();
        queen = GameObject.Find("Queen");
    }
    
    public void Register(GameObject tmp) { ants.Add(tmp); }
    public void Deregister(GameObject tmp) { ants.Remove(tmp); }

    public void Notify(GameObject tmp, string message, string info) {
        queen.GetComponent<AntSpawning>().OnNotify(tmp, message, info);
    }

    public void NotifyAllAnts(GameObject gameobj, string message) {
        foreach(GameObject ant in ants) {
            
        }
    }
}
