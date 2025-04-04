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

        //firstī�尡 ����ٸ�, firstī�忡 �� ������ �Ѱ��ش�.
        if (GameManager.Instance.firstCard == null)
        {
            GameManager.Instance.firstCard = this;
        }
        //firstī�尡 ������� �ʴٸ�, secondī�忡 �� ������ �Ѱ��ش�.
        else
        {
            GameManager.Instance.secondCard = this;
            //Mached �Լ� ȣ��
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
