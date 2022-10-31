using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailGun : MonoBehaviour
{
    public CharacterController controller; 
    private LineRenderer lr;
    public Transform GunPoint;
    public Transform player;
    private Vector3 gunPos;
    private Vector3 currentGrapplePosition;
    public Transform camera;
    public float mouseSensitivity = 500f;

    public float maxDistance = 100f;
    float xRotation = 0f;
    Vector3 oldPos;
    // Start is called before the first frame update
    void Awake() {
        lr = GetComponent<LineRenderer>();
    }

    void Update(){
        calculatingLine();
        DrawLine();
        pushPlayerToPoint ();
        
    }
    void DrawLine(){

        lr.SetPosition(0, currentGrapplePosition);
        lr.SetPosition(1, gunPos);
    }
    void calculatingLine (){
        float y = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
 
        transform.localRotation = Quaternion.Euler(xRotation,0,0);

         
        currentGrapplePosition = GunPoint.transform.position;
        RaycastHit hit;
 
        Ray theRay = new Ray(GunPoint.transform.position, camera.forward*10f);
        Debug.DrawRay(camera.transform.position, camera.forward*10f, Color.red);
        if(Input.GetMouseButtonDown(0) && Physics.Raycast(camera.transform.position, camera.forward, out hit, maxDistance)){
            gunPos = hit.point;
            Vector3 oldPos = player.transform.position;
        }
    }
    void pushPlayerToPoint (){
        
        float distanceFromPoint = Vector3.Distance(player.position, gunPos);
        
       
    }
}
