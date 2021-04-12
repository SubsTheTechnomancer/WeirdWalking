using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{

    Transform t;
    Collider coll;

    float initAngle;
    public int isRotating = 0;
    public Vector3 pivot;
    public float speed = 60.0f;
    public float constrain = 100.0f;

    void Start(){
        t = GetComponent<Transform>();
        coll = GetComponent<Collider>();
        initAngle = t.eulerAngles.y;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && isRotating == 0){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(coll.Raycast(ray, out hit,10.0f)){
                if(t.eulerAngles.y>initAngle) isRotating = -1;
                else isRotating = 1; 
            }

        }

        if(isRotating==1)
            t.RotateAround(pivot,Vector3.up,speed*Time.deltaTime);
        else if(isRotating == -1)
            t.RotateAround(pivot,Vector3.down,speed*Time.deltaTime);

        if(t.eulerAngles.y>=initAngle+constrain || t.eulerAngles.y <= initAngle) isRotating = 0;

    }
}
