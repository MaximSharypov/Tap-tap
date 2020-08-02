using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour{

    public int score;
    public int record;

    void Start()
    {
       
    }
    void Update()
    {       
        if (score > record){
            PlayerPrefs.SetInt("savescore",score);
            PlayerPrefs.Save();
            Debug.Log("Save");
        } 
        record = PlayerPrefs.GetInt ("savescore");
    }
}
