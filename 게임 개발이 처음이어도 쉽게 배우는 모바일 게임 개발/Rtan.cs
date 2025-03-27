using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rtan : MonoBehaviour
{
    float direction = 0.05f; //direction ���� ����, �̵� ���� �� �ʱ�ȭ
    SpriteRenderer renderer; //renderer ���� ����
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60; //������� ��ǻ�� ���ɿ� ���� ������ �����ϱ� ���� ��� Frame�� 60�� ����
        renderer = GetComponent<SpriteRenderer>(); //SpriteRenderer���� �ҷ����� ���� �Լ�
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //���콺 ����(0)��ư�� �������� (����� ������ ��ư��(1)�̴�.
        {
            direction *= -1; //���Ⱚ�� (-)�� �������ν� ���ϴ� ������ �ݴ�� ��ȯ�ϰ� �Ѵ�.
            renderer.flipX = !renderer.flipX; //filp���� false���� �־ �̹����� �����ǰ� �Ѵ�.
        }
        if (transform.position.x > 2.6f) //x���� 2.6���� ū ���(�����ʳ��� ���������Ƿ� �������� ���ϴ� ���)
        {
            direction = -0.05f; //(-)�� �������ν� �������� ���ϰ� �Ѵ�. * 0.05f�� ���ؼ� �ӵ��� ������ ��.
            renderer.flipX = true; //flip���� true�̹Ƿ� üũ�ڽ��� üũ�Ǿ��ִ� ����(��������)
        }
        if (transform.position.x < -2.6f) //x���� -2.6���� ���� ���(���ʳ��� ���������Ƿ� ���������� ���ؾ� ��)
        {
            direction = 0.05f;
            renderer.flipX = false;
        }
        transform.position += Vector3.right * direction; // �⺻ ��ġ���� �������� �̵�
    }
}
