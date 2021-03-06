using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    
    CharacterController character;
    FootstepsHandler fHandler;
    
    public float MovementSpeed = 1;
    public float Gravity = 9.8f;
    public float velocity = 0;

    void Start()
    {
        character = GetComponent<CharacterController>();
        fHandler = GetComponent<FootstepsHandler>();
    }


    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal")*MovementSpeed;
        float vertical = Input.GetAxis("Vertical")*MovementSpeed;
        character.Move((transform.right*horizontal+transform.forward*vertical)*Time.deltaTime);

        //Make footsteps flag true
        if(horizontal != 0.0f || vertical != 0.0f)
            fHandler.IsWalking = true;
        else
            fHandler.IsWalking = false;

        if(character.isGrounded)
            velocity = 0;
        else{
            velocity -= Gravity*Time.deltaTime;
            character.Move(new Vector3(0,velocity,0));
        }   
    }
}
