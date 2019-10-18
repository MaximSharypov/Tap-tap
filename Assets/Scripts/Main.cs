using UnityEngine;
using System;
using Debug=UnityEngine.Debug;
using Random=System.Random;

public class Main : MonoBehaviour {
    
    GameObject sphere;
    Vector3 targetPosition;

    void Start() {
        Debug.Log("start");
        sphere = GameObject.Find("Sphere");
        Debug.Log(sphere.transform.position);
    }

    void Update() {

        if (Input.GetMouseButtonDown(0)) {

            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(targetPosition);

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform.name == "Sphere" ) {
                    Debug.Log("My object is clicked by mouse");
                    Debug.Log(Screen.width);
                    Debug.Log(Screen.height);
                    ChangePosition();
                }
            }
        }

        // Debug.Log(sphere.transform.position);
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
        // int random_width_pos = -10;
        // int random_height_pos = 10;

        // float ScreenWidthInch = Screen.width / Screen.dpi;
        // float ScreenHeightInch = Screen.height / Screen.dpi;
        // Debug.Log(ScreenWidthInch + " " + ScreenHeightInch);
        Debug.Log(random_width_pos);
        Debug.Log(random_height_pos);
        sphere.transform.localPosition = new Vector3(random_width_pos, random_height_pos, 0);
        // transform.position += new Vector3(1, 1, 0);
    }

}