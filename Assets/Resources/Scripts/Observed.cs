using UnityEngine;
using System.Collections;

public class Observed : MonoBehaviour {

    private ArrayList ants;

    void Awake()
    {
        ants = new ArrayList();
    }
    
    public void Register(GameObject tmp) { ants.Add(tmp); }
    public void Deregister(GameObject tmp) { ants.Remove(tmp); }

    public void Notify(GameObject tmp) {

    }

    public void NotifyAllAnts(string message) {
        foreach(GameObject ant in ants) {

        }
    }
}
