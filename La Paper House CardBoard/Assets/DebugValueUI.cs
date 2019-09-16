using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DebugValueUI : MonoBehaviour
{
    public Text uiText;
    public TextMesh text3D;
    public VirandolaRead virandola;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateValue();
    }

    void UpdateValue(){
        text3D.text = virandola.finalValue.ToString();
        //uiText.text = virandola.finalValue.ToString();
    }
}
