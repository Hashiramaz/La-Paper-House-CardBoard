using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
public class VirandolaRead : MonoBehaviour
{
        SerialPort vir = new SerialPort("COM7", 9600);
    
    public float finalValue;
    public float virandola = 0;
    public float reduction = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        vir.Open();
        //vir.ReadTimeout = 2;
    }

    // Update is called once per frame
    void LateUpdate()
    {
       
            // try
            // {
            //     //Apenas pra Debug
            //     //print();

            //     virandola = reduce_value(float.Parse(vir.ReadLine()), reduction);
            // }
            // catch (System.Exception)
            // {
            //     throw;
            // }
            ReadValue();
            NormalizeValue();
        
    }
    

    public void ReadValue(){
         if (vir.IsOpen)
        {
                virandola = reduce_value(float.Parse(vir.ReadLine()), reduction);
        }
    }

    public void NormalizeValue(){
        finalValue = Mathf.Lerp(virandola,finalValue,Time.deltaTime);
    }

    public float reduce_value(float amount, float reduction)
    {
        return amount / reduction;
    } 
}
