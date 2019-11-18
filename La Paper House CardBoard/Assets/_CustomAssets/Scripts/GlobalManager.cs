using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalManager : MonoBehaviour
{


    private void Update() {
        if(Input.GetButtonDown("Fire3")){
            RestartScene();
        }
    }


    public void RestartScene(){
        SceneManager.LoadScene(0);
    }
}
