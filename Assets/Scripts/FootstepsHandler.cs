using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsHandler : MonoBehaviour
{
    
    public bool IsWalking = false;

    AudioSource footsteps;

    void Start(){
        footsteps = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if(IsWalking && !footsteps.isPlaying){
            footsteps.Play();
        }
        else if(!IsWalking){
            footsteps.Pause();
        }
    }
}
