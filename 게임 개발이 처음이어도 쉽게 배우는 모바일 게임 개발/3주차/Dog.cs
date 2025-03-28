using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Dog : MonoBehaviour
{

    public GameObject food;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeFood", 0f, 0.2f); //강아지가 계속 밥을 날리게 하는 로직
    }

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //스크린상의 마우스 위치를 게임 월드 상의 카메라(메인)의 위치로 바꿔준다.
        float x = mousePos.x;
        if (x > 8.5f) //강아지가 화면(가게)밖으로 나오지 못하게 하는 함수
        {
            x = 8.5f;
        }
        if (x < -8.5f)
        {
            x = -8.5f;
        }
        //강아지는 좌우로만 움직일 것이기때문에 x값만 필요하다.
        transform.position = new Vector2(x, transform.position.y); //x값만 바꾸고 y값은 그대로 유지

    }

    void MakeFood()
    {
        //어느 위치에서 생성할지
        float x = transform.position.x; //강아지의 x값을 받는 실수형 변수 x
        float y = transform.position.y + 2.0f; //강아지의 y값을 받는 실수형 변수 y +2(강아지 머리위에서 나오게 하기 위함)
        //반복적으로 Food를 생성하는 로직
        Instantiate(food, new Vector2(x, y), Quaternion.identity); //Quaternion.identity == 별도의 회전값을 주지 않겠다.
    }
}
