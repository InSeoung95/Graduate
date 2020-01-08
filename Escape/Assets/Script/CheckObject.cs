using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //오브젝트 이동
        //transform.Translate(Vector3.right * Time.deltaTime);


        //오브젝트가 카메라 안에 있는지 확인
        // Debug.Log(Checking(gameObject));
    }

    public bool Checking(GameObject target)
    {
        Camera selectedCameta = GameObject.Find("Main Camera").GetComponent<Camera>(); //Main Camera 카메라 이름 적기
        Vector3 screenPoint = selectedCameta.WorldToViewportPoint(target.transform.position);
        //screenPoint 0~1 사이의 값을 주어 제한해서 시야를 정해줄수있음
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0.3 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

        return onScreen;
    }
}
