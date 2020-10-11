using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
	
    public int plateNo;
    public ParticleSystem novaEffect;
 

    //Public method which is called by playercontroller
    public void ShowParticle() 
    {
        novaEffect.Play();
    }
 
}
