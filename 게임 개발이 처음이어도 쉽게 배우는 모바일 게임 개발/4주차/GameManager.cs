using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Card firstCard;
    public Card secondCard;

    public Text TimeTxt;
    float time = 0.0f;

    public GameObject endTxt; //게임오버가 됐을 때 보이게 해줄 변수
    public int cardCount = 0; //플레이어가 카드를 몇 장 맞추는지 파악

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        time += Time.deltaTime;
        TimeTxt.text = time.ToString("N2");
    }

    public void Matched()
    {
        //연 카드 2장이 같지 않다면 닫아주고 같다면 파괴
        if(firstCard.idx == secondCard.idx)
        {
            firstCard.DestoryCard();
            secondCard.DestoryCard();
            cardCount -= 2; //카드를 두 장 맞췄음
            if(cardCount == 0) //카드를 모두 맞추면
            {
                Time.timeScale = 0.0f;
                endTxt.SetActive(true);
            }
         
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard = null;
        secondCard = null;
    }
}
