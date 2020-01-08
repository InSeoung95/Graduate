using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    private Vector3 mousePos;
    public Camera camera;
    //public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mouseClick();
       // Debug.Log("hit");
    }

    GameObject temp1;
    void mouseClick()
    {
         if (Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (mousePos == Input.mousePosition)
            {
                Ray ray = camera.ScreenPointToRay(mousePos);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100)) // 100 거리를 나타낸다.
                {
                    Debug.Log(hit.collider.gameObject);

                    if (hit.collider.gameObject.name == "Sphere")
                    {
                        temp1 = Resources.Load("Sphere") as GameObject;
                        Instantiate(temp1, camera.transform.position + new Vector3(1, 0, 0), transform.rotation);
                    }
                    // prefab = "Sphere";
                    //Instantiate(prefab, camera.transform.position + new Vector3(1, 0, 0), transform.rotation);
               
                    //Debug.DrawLine(ray.origin, ray.direction);
                    //Debug.Log("hit");
                    //hit.collider.gameObject.renderer.enabled = false;
                }
            }
        }
    }

}


