using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{

    public GameObject card;

    void Start()
    {
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        arr = arr.OrderBy(x => Random.Range(0f, 7f)).ToArray();

        for(int i = 0; i < 16; i++) 
        {
            GameObject go = Instantiate(card, this.transform); //보드 밑에 prefab이 16개 생김

            float x = (i % 4) * 1.4f - 2.1f; //나머지
            float y = (i / 4) * 1.4f - 3.0f; //몫

            go.transform.position = new Vector2(x,y);
            go.GetComponent<Card>().Setting(arr[i]);
        }

        GameManager.Instance.cardCount = arr.Length; //세팅되는 카드의 수가 배열의 크기(총 수량)만큼인지 파악
    }

    void Update()
    {
        
    }
}
