using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ȭ�� ��ũ������ ���콺 ��ġ�� ���� ī�޶� ��� �ִ� ���� ������� ��ġ�� �˱� ���� �ڵ�.
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);  //���콺�� ��ġ�� ī�޶�� ��� �ִ� ���� ���� ���� ��ġ�� �ٲ��ִ� �Լ��� MousePos��� ������ �־���.
        transform.position = mousePos;//����Ƽ�� transform�� �����ؼ� ��ȯ�� ���콺 ��ġ�� shield ��ġ�� �־��ִ� ��
    }
}
