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

    public GameObject endTxt; //���ӿ����� ���� �� ���̰� ���� ����
    public int cardCount = 0; //�÷��̾ ī�带 �� �� ���ߴ��� �ľ�

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
        //�� ī�� 2���� ���� �ʴٸ� �ݾ��ְ� ���ٸ� �ı�
        if(firstCard.idx == secondCard.idx)
        {
            firstCard.DestoryCard();
            secondCard.DestoryCard();
            cardCount -= 2; //ī�带 �� �� ������
            if(cardCount == 0) //ī�带 ��� ���߸�
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
