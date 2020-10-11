using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideRendererController : MonoBehaviour
{
    public Material mat01;
    public Material mat02;

    List<string> plateTagList ;

    // Start is called before the first frame update    

    void Start()
    {
        //Set Plate Tag List
        
        plateTagList = new List<string>();
        plateTagList.Add("Plate");
        plateTagList.Add("BreakPlate");
        plateTagList.Add("JumpPlate");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {   
        //When player is entered to Plate shadow must be green
        
        if( plateTagList.Contains( other.tag ) ) 
        {            
              GetComponent<MeshRenderer>().material = mat01;    
        } 
    }

    private void OnTriggerExit(Collider other)
    {   
        //When player is exited from plate shadow must be red        
        
       if( plateTagList.Contains( other.tag ) )
       {
               GetComponent<MeshRenderer>().material = mat02;           
       }
    }


}
