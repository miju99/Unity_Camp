using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class Cat : MonoBehaviour
{

    public GameObject hungryCat; //에너지바가 다 찼을 때 고양이 이미지를 변경
    public GameObject fullCat; //에너지바가 다 찼을 때 고양이 이미지를 변경

    public RectTransform front; //게이지바

    public int type; //noramcat과 fatcat 구분을 위한 변수

    float full = 5.0f; //게이지바 전체값
    float energy = 0.0f; //푸드 하나당 게이지바가 차는 비율
    float speed = 0.05f; //고양이가 내려오는 속도

    bool isFull = false;

    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-9.0f, 9.0f); //고양이 생성 위치가 랜덤한 x값을 가지도록 함.
        float y = 30.0f;
        transform.position = new Vector2(x, 30f);

        if(type == 1)//nomalcat
        {
            speed = 0.05f;
            full = 5f;
        }
        if(type == 2) //fatcat
        {
            speed = 0.02f;
            full = 10f;
        }
        if (type == 3)
        {
            speed = -0.1f;
            full = 3f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (energy < full) // 에너지가 다 차지 않았을 땐 고양이가 아래로 내려옴.
        {
            transform.position += Vector3.down * 0.05f;
            if(transform.position.y < -16.0f)
            {
                GameManager.Instance.GameOver();
            }
        }
        else
        {
            if (transform.position.x > 0)//고양이가 오른쪽에 있을 때
            {
                transform.position += Vector3.right*0.05f; //쭉 오른쪽으로 밀어줌
            }
            else //고양이가 왼쪽에 있을 때
            {
                transform.position += Vector3.left*0.05f; //쭉 왼쪽으로 밀어줌
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //is trigger 충돌 판정
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            if (energy < full)
            {  //에너지바가 가득 찼음에도 불구하고 에너지가 계속 차지 않게 하기위해
                energy += 1.0f; //푸드를 맞을때마다 1씩 차는 에너지
                front.localScale = new Vector3(energy / full, 1.0f, 1.0f); //에너지값을 front 게이지에 반영해주기 위함 -> scale의 x값에 넣어줘야함 new Vector3 (x,y,z);
                Destroy(collision.gameObject); //뒤에 있는 고양이도 같은 밥에 맞으면 안되니 충돌하면 밥을 삭제한다.

                if(energy == 5.0f)
                {
                    if (!isFull)
                    {
                        isFull = true;
                        hungryCat.SetActive(false); //고양이 이미지 변경
                        fullCat.SetActive(true); //고양이 이미지 변경
                        Destroy(gameObject, 3.0f); //에너지가 다 찬 고양이는 3초 뒤(화면밖에 나갔을 시간)에 사라진다.
                        GameManager.Instance.AddScroe(); //에너지가 다 찬 고양이에게 맞아도 score가 오른다. 그래서 isFull이 false일때만 실행될 수 있도록 한다.
                    }
                }
            }
        }
    }
}
