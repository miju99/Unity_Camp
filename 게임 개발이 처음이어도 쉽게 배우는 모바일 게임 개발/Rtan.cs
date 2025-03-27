using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rtan : MonoBehaviour
{
    float direction = 0.05f; //direction 변수 선언, 이동 방향 값 초기화
    SpriteRenderer renderer; //renderer 변수 선언
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60; //사용자의 컴퓨터 성능에 따른 편차를 예방하기 위해 모든 Frame을 60에 맞춤
        renderer = GetComponent<SpriteRenderer>(); //SpriteRenderer값을 불러오기 위한 함수
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //마우스 왼쪽(0)버튼을 눌렀을때 (참고로 오른쪽 버튼은(1)이다.
        {
            direction *= -1; //방향값에 (-)를 곱함으로써 향하는 방향의 반대로 전환하게 한다.
            renderer.flipX = !renderer.flipX; //filp값에 false값을 넣어서 이미지가 반전되게 한다.
        }
        if (transform.position.x > 2.6f) //x값이 2.6보다 큰 경우(오른쪽끝에 도달했으므로 왼쪽으로 향하는 경우)
        {
            direction = -0.05f; //(-)를 곱함으로써 왼쪽으로 향하게 한다. * 0.05f를 곱해서 속도를 느리게 함.
            renderer.flipX = true; //flip값이 true이므로 체크박스에 체크되어있는 상태(반전상태)
        }
        if (transform.position.x < -2.6f) //x값이 -2.6보다 작은 경우(왼쪽끝에 도달했으므로 오른쪽으로 향해야 함)
        {
            direction = 0.05f;
            renderer.flipX = false;
        }
        transform.position += Vector3.right * direction; // 기본 위치에서 우측으로 이동
    }
}
