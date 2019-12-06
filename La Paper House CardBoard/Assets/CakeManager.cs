using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Gui;
public class CakeManager : MonoBehaviour
{
    public ParticleSystem vela;
    public Light velalight;
    public bool cakeStarted = false;
    public LeanWindow parabenstext;
    public LeanWindow fade;

    public AudioSource cornetasound;
    // Start is called before the first frame update
    void Start()
    {
        fade.TurnOff();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Wind")){
            
            StartCoroutine(CakeRoutine());
        }
    }

    IEnumerator CakeRoutine(){
        if(cakeStarted){
            yield return null;
        }else{
            cakeStarted = true;
            // Apagar Vela
            vela.Stop();
            velalight.gameObject.SetActive(false);
            
            // mostrar o Parabens
            parabenstext.TurnOn();
            cornetasound.Play();
            // aguardar 

            yield return new WaitForSeconds(5f);
            fade.TurnOn();
            yield return new WaitForSeconds(3f);

            // Carregar a mesma cena
            GlobalManager.instance.RestartScene();
        }
        
    }

    public void ShowParabens(){

    }
}
