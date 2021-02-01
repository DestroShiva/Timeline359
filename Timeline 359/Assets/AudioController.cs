using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource[] audioS;
   
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    public void Fire(){
        audioS[0].Play();
        
    }
    public void StopFire(){
        audioS[0].Stop();
        
    }
    public void playFireTail(){
        audioS[1].Play();
    }
    
    

    public void footStepOne(){
        audioS[Random.Range(2, 9)].Play();
    }

   /* public void footStepTwo(){
        audioS[3].Play();
    }
    public void footStepThree(){
        audioS[4].Play();
    }
    public void footStepFour(){
        audioS[5].Play();
    }*/
    public void jump(){
        audioS[10].Play();
    }
    public void landing(){
        audioS[11].Play();
    }
     public void magOut(){
        audioS[12].Play();
    }
     public void magIn(){
        audioS[13].Play();
    }
     public void punch(){
        audioS[14].Play();
    }
     public void boltOpen(){
        audioS[15].Play();
    }
     public void boltRealease(){
        audioS[16].Play();
    }
     public void magPouch(){
        audioS[17].Play();
    }
    

}
