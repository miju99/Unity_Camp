using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    float size = 1.0f; //size 변수 초기화
    int score = 1; //score 변수 초기화

    SpriteRenderer renderer; //renderer 변수 선언

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>(); //SpriteRenderer값을 불러오기 위한 함수

        float x = Random.Range(-2.4f, 2.4f); //x방향으로 이동할 수 있는 범위
        float y = Random.Range(3.0f, 5.0f); //y방향으로 이동할 수 있는 범위

        transform.position = new Vector3(x, y, 0); //위에서 정의한 x,y 위치를 변수로 입력

        int type = Random.Range(1, 5); // 빗방울 타입 3개를 선언, range(x,y)에서 y보다 하나 작은 수를 인식하므로 원하는 수+1값을 넣어줘야 한다.

        if (type == 1) // 빗방울 타입 1 (가장 작은 빗방울)
        {
            size = 0.8f;
            score = 1;
            renderer.color = new Color(100 / 255f, 100 / 255f, 1f, 1f);
        }
        else if (type == 2) // 빗방울 타입 2 (중간 빗방울)
        {
            size = 1.0f;
            score = 2;
            renderer.color = new Color(130 / 255f, 130 / 255f, 1f, 1f);
        }
        else if (type == 3) // 빗방울 타입 3 (가장 큰 빗방울)
        {
            size = 1.2f;
            score = 3;
            renderer.color = new Color(150 / 255f, 150 / 255f, 1f, 1f);
        }
        else if (type == 4)
        {
            size = 0.8f;
            score = -5;
            renderer.color = new Color(255f, 100 / 255f, 255f, 1f);
        }
            transform.localScale = new Vector3(size, size, 0); //빗방울들의 사이즈를 size 변수로 불러옴
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) //Gound라는 태그에 속한 오브젝트와 충돌할 경우
        {
            Destroy(this.gameObject); //해당 오브젝트를 파괴하는 명령어
        }
        if (collision.gameObject.CompareTag("Player"))//르탄이에게 Player태그를 부여하고, 충돌체에 해당 태그가 있는지 비교하는 로직
        {
            GameManager.Instance.AddScore(score); //위에서 미리 정의해놓은 타입에 따른 score를 불러오는 함수(AddScore라는 로직을 불러오기 위해 Instace변수를 통해 불러온다.
            Destroy(this.gameObject);
        }
    }
}
