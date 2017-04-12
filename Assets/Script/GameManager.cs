using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Restart();
	}

    void Restart()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
