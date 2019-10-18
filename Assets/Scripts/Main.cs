using UnityEngine;
using System;
using Debug=UnityEngine.Debug;
using Random=System.Random;

public class Main : MonoBehaviour {
    
    GameObject sphere;

    void Start() {
        print("start");
        sphere = GameObject.Find("Sphere");
    }

    void Update() {

        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform.name == "Sphere" ) {
                    print("My object is clicked by mouse");
                    ChangePosition();
                }
            }
        }

    }

    void ChangePosition() {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        int height_int = (int) (height / 2);
        int width_int = (int) (width / 2);
        Random rnd = new Random();
        int random_width_pos = rnd.Next(- width_int, width_int);
        int random_height_pos = rnd.Next(- height_int, height_int);
        print("new X position: " + random_width_pos + ", new Y position: " + random_height_pos);
        sphere.transform.position = new Vector3(random_width_pos, random_height_pos, 0);
    }

}