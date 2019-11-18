using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.IO;


#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif
public class VirandolaRead : MonoBehaviour
{
    GameObject dialog = null;
        SerialPort vir = new SerialPort("COM7", 9600);
    
    public float finalValue;
    public float virandola = 0;
    public float reduction = 100;
    
    // Start is called before the first frame update
    void Start()
    {

        #if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission("android.hardware.usb.action.USB_DEVICE_DETACHED"))
        {
            Permission.RequestUserPermission("android.hardware.usb.action.USB_DEVICE_DETACHED");
            dialog = new GameObject();
            }
        #endif
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


     void OnGUI ()
    {
        #if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission("android.hardware.usb.action.USB_DEVICE_DETACHED"))
        {
            // The user denied permission to use the microphone.
            // Display a message explaining why you need it with Yes/No buttons.
            // If the user says yes then present the request again
            // Display a dialog here.
            //dialog.AddComponent<PermissionsRationaleDialog>();
            
            return;
        }
        else if (dialog != null)
        {
            Destroy(dialog);
        }
        #endif

        // Now you can do things with the microphone
    }   
}
