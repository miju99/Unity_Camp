using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int idx = 0;
    public SpriteRenderer frontImage;

    public GameObject front;
    public GameObject back;

    public Animator anim;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Setting(int number)
    {
        idx = number;
        frontImage.sprite = Resources.Load<Sprite>($"rtan{idx}");
    }

    public void OpenCard()
    {
        anim.SetBool("isOpen",true);
        front.SetActive(true);
        back.SetActive(false);

        //first카드가 비었다면, first카드에 내 정보를 넘겨준다.
        if (GameManager.Instance.firstCard == null)
        {
            GameManager.Instance.firstCard = this;
        }
        //first카드가 비어있지 않다면, second카드에 내 정보를 넘겨준다.
        else
        {
            GameManager.Instance.secondCard = this;
            //Mached 함수 호출
            GameManager.Instance.Matched();
        }
    }
    public void DestoryCard()
    {
        Invoke("DestroyCardInvoke", 1.0f);
    }

    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 1.0f);
    }
    public void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }
}
