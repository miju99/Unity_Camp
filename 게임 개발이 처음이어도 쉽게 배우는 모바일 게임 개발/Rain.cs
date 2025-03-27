using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    float size = 1.0f; //size ���� �ʱ�ȭ
    int score = 1; //score ���� �ʱ�ȭ

    SpriteRenderer renderer; //renderer ���� ����

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>(); //SpriteRenderer���� �ҷ����� ���� �Լ�

        float x = Random.Range(-2.4f, 2.4f); //x�������� �̵��� �� �ִ� ����
        float y = Random.Range(3.0f, 5.0f); //y�������� �̵��� �� �ִ� ����

        transform.position = new Vector3(x, y, 0); //������ ������ x,y ��ġ�� ������ �Է�

        int type = Random.Range(1, 5); // ����� Ÿ�� 3���� ����, range(x,y)���� y���� �ϳ� ���� ���� �ν��ϹǷ� ���ϴ� ��+1���� �־���� �Ѵ�.

        if (type == 1) // ����� Ÿ�� 1 (���� ���� �����)
        {
            size = 0.8f;
            score = 1;
            renderer.color = new Color(100 / 255f, 100 / 255f, 1f, 1f);
        }
        else if (type == 2) // ����� Ÿ�� 2 (�߰� �����)
        {
            size = 1.0f;
            score = 2;
            renderer.color = new Color(130 / 255f, 130 / 255f, 1f, 1f);
        }
        else if (type == 3) // ����� Ÿ�� 3 (���� ū �����)
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
            transform.localScale = new Vector3(size, size, 0); //�������� ����� size ������ �ҷ���
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) //Gound��� �±׿� ���� ������Ʈ�� �浹�� ���
        {
            Destroy(this.gameObject); //�ش� ������Ʈ�� �ı��ϴ� ��ɾ�
        }
        if (collision.gameObject.CompareTag("Player"))//��ź�̿��� Player�±׸� �ο��ϰ�, �浹ü�� �ش� �±װ� �ִ��� ���ϴ� ����
        {
            GameManager.Instance.AddScore(score); //������ �̸� �����س��� Ÿ�Կ� ���� score�� �ҷ����� �Լ�(AddScore��� ������ �ҷ����� ���� Instace������ ���� �ҷ��´�.
            Destroy(this.gameObject);
        }
    }
}
