using UnityEngine;
using System.Collections;

abstract public class Observer : MonoBehaviour {

    abstract public void OnNotify(GameObject observed, string message, string info);
}
