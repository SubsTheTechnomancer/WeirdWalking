using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillations : MonoBehaviour
{
    
    public Vector3 initialPosition;
    public Vector3 finalPosition;

    public Vector3 initialRotation;
    public Vector3 finalRotation;

    public float speed = 1f;

    Transform t;
    

    void Start(){
        t = GetComponent<Transform>();
    }

    void Update(){

        float speedx = speed*(finalPosition.x-initialPosition.x+0.001f);
        float speedy = speed*(finalPosition.y-initialPosition.y+0.001f);
        float speedz = speed*(finalPosition.z-initialPosition.z+0.001f);

        float speedrx = speed*(finalRotation.x-initialRotation.x+0.001f);
        float speedry = speed*(finalRotation.y-initialRotation.y+0.001f);
        float speedrz = speed*(finalRotation.z-initialRotation.z+0.001f);


        float newx = initialPosition.x + Mathf.Sign(finalPosition.x-initialPosition.x+0.001f)*Mathf.PingPong(Time.time*speedx,Mathf.Abs(finalPosition.x-initialPosition.x+0.01f));
        float newy = initialPosition.y + Mathf.Sign(finalPosition.y-initialPosition.y+0.001f)*Mathf.PingPong(Time.time*speedy,Mathf.Abs(finalPosition.y-initialPosition.y+0.01f));
        float newz = initialPosition.z + Mathf.Sign(finalPosition.z-initialPosition.z+0.001f)*Mathf.PingPong(Time.time*speedz,Mathf.Abs(finalPosition.z-initialPosition.z+0.01f));

        float newrx = initialRotation.x + Mathf.Sign(finalRotation.x-initialRotation.x+0.001f)*Mathf.PingPong(Time.time*speedrx,Mathf.Abs(finalRotation.x-initialRotation.x+0.01f));
        float newry = initialRotation.y + Mathf.Sign(finalRotation.y-initialRotation.y+0.001f)*Mathf.PingPong(Time.time*speedry,Mathf.Abs(finalRotation.y-initialRotation.y+0.01f));
        float newrz = initialRotation.z + Mathf.Sign(finalRotation.z-initialRotation.z+0.001f)*Mathf.PingPong(Time.time*speedrz,Mathf.Abs(finalRotation.z-initialRotation.z+0.01f));

        t.position = new Vector3(newx,newy,newz);
        t.rotation = Quaternion.Euler(newrx,newry,newrz);
    }
}
