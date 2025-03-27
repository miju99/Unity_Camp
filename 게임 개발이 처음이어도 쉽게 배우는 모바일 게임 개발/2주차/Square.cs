using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Square : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-3f, 3f); //움직일 수 있는 최소 x 위치값와 최대 x 위치값
        float y = Random.Range(3.0f, 5.0f); //움직일 수 있는 최소 y 위치값와 최대 y 위치값

        transform.position = new Vector3 (x, y, 0); //유니티 transform-Position에 랜덤한 x,y값 입력

        float size = Random.Range(0.5f, 1.5f); //랜덤한 크기의 Square 생성
        transform.localScale = new Vector2(size, size); //유니티 Transform-Scale에 랜덤한 size 입력

    }

    // Update is called once per frame
    void Update()
    {

    }

    /* 숙제 : 떨어지는 네모를 없애기
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    */

    public void OnCollisionEnter2D(Collision2D collision) //collision(충돌)된 오브젝트 중에서
    {
        if (collision.gameObject.CompareTag("Player")) //태그가 Player인지 검사
        {
            GameManager.instance.GameOver();
        }
    }
}
