using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    private static SoundManager instance = null;
    public static SoundManager Instance;
    public ArrayList sounds;

    void Start()
    {
        sounds = new ArrayList();
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}