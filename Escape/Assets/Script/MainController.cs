using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    //이동
    public Animator animator;
    public float speed = 10;
    private float h; // 좌,우
    private float v; // 상,하

    //시야전환
    public Camera cam;
    public float rotateSpeed = 5f;
    public float cameraRotationLimit = 80f;
    private float cameraRotation = 0f;
    private float currentCameraRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      
        movePlayer();
        eyeRotation();
  

    }


    void eyeRotation()  //x,y 회전(시야회전)
    {

        float rotX = Input.GetAxis("Mouse Y") * rotateSpeed;    
        float rotY = Input.GetAxis("Mouse X") * rotateSpeed;

        this.transform.localRotation *= Quaternion.Euler(0, rotY, 0);
        cam.transform.localRotation *= Quaternion.Euler(-rotX, 0, 0);

        cameraRotation = rotX;

        if (cam != null)
        {
            currentCameraRotation -= cameraRotation;
            currentCameraRotation = Mathf.Clamp(currentCameraRotation, -cameraRotationLimit, cameraRotationLimit);
            cam.transform.localEulerAngles = new Vector3(currentCameraRotation, 0f, 0f);
        }
    }

    void movePlayer() 
    {

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        animator.SetFloat("h", h);
        animator.SetFloat("v", v);

        //Time.smoothDeltaTime cpu마다 성능이 달라서 곱해준다.
        if (Input.GetKey("a"))
        {
            transform.position = new Vector3(transform.position.x - (speed * Time.smoothDeltaTime), transform.position.y, transform.position.z);
        }
        else if (Input.GetKey("d"))
        {
            transform.position = new Vector3(transform.position.x + (speed * Time.smoothDeltaTime), transform.position.y, transform.position.z);
        }
        else if (Input.GetKey("s"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (speed * Time.smoothDeltaTime));
        }
        else if (Input.GetKey("w"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (speed * Time.smoothDeltaTime));
        }
 
    }
}


