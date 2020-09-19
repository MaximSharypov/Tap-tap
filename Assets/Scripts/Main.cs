using UnityEngine;
using System;
using Debug=UnityEngine.Debug;
using Random=System.Random;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Main : MonoBehaviour {

public Text countdownText, Score, Record;

    float currentTime = 2f;     
    float duration = 2.0f; 
    float minusTime = 0.02f; 
    public GameObject sphere, lose_buttons;
    bool firstTap = false, lose;
    public int score;
    public int record;
    public GameObject ButDeadF;
    public AudioClip DeadF;
    public int Pos_X  = 750;
    public int Pos_Y = 150;
    private int PlusOne = 1;


    void Start() {
        print("start");
        sphere = GameObject.Find("Sphere");
    }

    void Update() {
        if (firstTap == true){
        currentTime -= Time.deltaTime;
        countdownText.text = currentTime.ToString ("0.00");
        }
        if (score > record){
            PlayerPrefs.SetInt("savescore",score);
            PlayerPrefs.Save();
            Debug.Log("Save");
        } 
        if (currentTime <= 0){
            currentTime = 0;
            Destroy (sphere);
            print ("Player Lose");
            lose = true;
        }
        if (lose)
            PlayerLose ();

        record = PlayerPrefs.GetInt ("savescore");
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform.name == "Sphere" ) {
                    currentTime = duration;
                    duration -= minusTime;
                    score += PlusOne;
                    Score.text = score.ToString ("0");
                    Record.text = record.ToString ("TOP: 0");
                    if (firstTap == false){
                        firstTap = true;
                    }
                       
                    print("My object is clicked by mouse");                   
                    ChangePosition();
                }
            }
        }

    }
    void PlayerLose ()
    {
        if (!lose_buttons.activeSelf)
            lose_buttons.SetActive (true);                        
            int Pos_Z = (0);
            lose_buttons.transform.position = new Vector3 (Pos_X, Pos_Y, Pos_Z);
            Debug.Log("перед");
    }

    void ChangePosition() {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        int height_int = (int) (height / 2);
        int width_int = (int) (width / 2);
        Random rnd = new Random();
        int random_width_pos = rnd.Next(- width_int +1, width_int -1);
        int random_height_pos = rnd.Next(- height_int +1, height_int -1);
        print("new X position: " + random_width_pos + ", new Y position: " + random_height_pos);
        sphere.transform.position = new Vector3(random_width_pos, random_height_pos, 0);
    }

     void OnMouseDown ()
        {
                if (ButDeadF == true)
                        AudioSource.PlayClipAtPoint (DeadF, transform.position);
        }
}
