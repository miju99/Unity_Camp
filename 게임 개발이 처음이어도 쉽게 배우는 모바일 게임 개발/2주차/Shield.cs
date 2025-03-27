using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //화면 스크린상의 마우스 위치와 메인 카메라가 찍고 있는 게임 월드상의 위치를 알기 위한 코드.
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);  //마우스의 위치를 카메라로 찍고 있는 게임 월드 상의 위치로 바꿔주는 함수를 MousePos라는 변수에 넣었음.
        transform.position = mousePos;//유니티의 transform에 접근해서 변환한 마우스 위치를 shield 위치로 넣어주는 것
    }
}
