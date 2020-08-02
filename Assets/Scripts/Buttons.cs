using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Buttons : MonoBehaviour{
 
    public void EndGame () {
        Debug.Log("GAME OVER");
        print("Restart");
        switch (gameObject.name) {
        case "Button":           
            SceneManager.LoadScene ("Main");
            break;          
       }
        
    }  

}
