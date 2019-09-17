using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateTextValues : MonoBehaviour
{
    public manager manag;

    public TextMesh text;

    private void Update() {
        text.text = manag.value;
    }
}
