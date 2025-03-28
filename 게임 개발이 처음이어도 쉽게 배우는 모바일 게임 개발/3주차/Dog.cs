using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Dog : MonoBehaviour
{

    public GameObject food;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeFood", 0f, 0.2f); //�������� ��� ���� ������ �ϴ� ����
    }

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //��ũ������ ���콺 ��ġ�� ���� ���� ���� ī�޶�(����)�� ��ġ�� �ٲ��ش�.
        float x = mousePos.x;
        if (x > 8.5f) //�������� ȭ��(����)������ ������ ���ϰ� �ϴ� �Լ�
        {
            x = 8.5f;
        }
        if (x < -8.5f)
        {
            x = -8.5f;
        }
        //�������� �¿�θ� ������ ���̱⶧���� x���� �ʿ��ϴ�.
        transform.position = new Vector2(x, transform.position.y); //x���� �ٲٰ� y���� �״�� ����

    }

    void MakeFood()
    {
        //��� ��ġ���� ��������
        float x = transform.position.x; //�������� x���� �޴� �Ǽ��� ���� x
        float y = transform.position.y + 2.0f; //�������� y���� �޴� �Ǽ��� ���� y +2(������ �Ӹ������� ������ �ϱ� ����)
        //�ݺ������� Food�� �����ϴ� ����
        Instantiate(food, new Vector2(x, y), Quaternion.identity); //Quaternion.identity == ������ ȸ������ ���� �ʰڴ�.
    }
}
