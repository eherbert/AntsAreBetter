﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayButtonScript : MonoBehaviour {

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) SceneManager.LoadScene("MainScene");
    }
}
