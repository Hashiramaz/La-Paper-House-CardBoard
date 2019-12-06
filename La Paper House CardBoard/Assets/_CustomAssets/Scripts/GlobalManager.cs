using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager instance;
    private void Awake() {
        if(instance == null)
            instance = this;
        
    }

    private void Update() {
        if(Input.GetButtonDown("Fire3")){
            RestartScene();
        }
    }


    public void RestartScene(){
        SceneManager.LoadScene(0);
    }
}
