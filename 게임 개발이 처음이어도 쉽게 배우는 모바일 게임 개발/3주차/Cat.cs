using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class Cat : MonoBehaviour
{

    public GameObject hungryCat; //�������ٰ� �� á�� �� ����� �̹����� ����
    public GameObject fullCat; //�������ٰ� �� á�� �� ����� �̹����� ����

    public RectTransform front; //��������

    public int type; //noramcat�� fatcat ������ ���� ����

    float full = 5.0f; //�������� ��ü��
    float energy = 0.0f; //Ǫ�� �ϳ��� �������ٰ� ���� ����
    float speed = 0.05f; //����̰� �������� �ӵ�

    bool isFull = false;

    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-9.0f, 9.0f); //����� ���� ��ġ�� ������ x���� �������� ��.
        float y = 30.0f;
        transform.position = new Vector2(x, 30f);

        if(type == 1)//nomalcat
        {
            speed = 0.05f;
            full = 5f;
        }
        if(type == 2) //fatcat
        {
            speed = 0.02f;
            full = 10f;
        }
        if (type == 3)
        {
            speed = -0.1f;
            full = 3f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (energy < full) // �������� �� ���� �ʾ��� �� ����̰� �Ʒ��� ������.
        {
            transform.position += Vector3.down * 0.05f;
            if(transform.position.y < -16.0f)
            {
                GameManager.Instance.GameOver();
            }
        }
        else
        {
            if (transform.position.x > 0)//����̰� �����ʿ� ���� ��
            {
                transform.position += Vector3.right*0.05f; //�� ���������� �о���
            }
            else //����̰� ���ʿ� ���� ��
            {
                transform.position += Vector3.left*0.05f; //�� �������� �о���
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //is trigger �浹 ����
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            if (energy < full)
            {  //�������ٰ� ���� á������ �ұ��ϰ� �������� ��� ���� �ʰ� �ϱ�����
                energy += 1.0f; //Ǫ�带 ���������� 1�� ���� ������
                front.localScale = new Vector3(energy / full, 1.0f, 1.0f); //���������� front �������� �ݿ����ֱ� ���� -> scale�� x���� �־������ new Vector3 (x,y,z);
                Destroy(collision.gameObject); //�ڿ� �ִ� ����̵� ���� �信 ������ �ȵǴ� �浹�ϸ� ���� �����Ѵ�.

                if(energy == 5.0f)
                {
                    if (!isFull)
                    {
                        isFull = true;
                        hungryCat.SetActive(false); //����� �̹��� ����
                        fullCat.SetActive(true); //����� �̹��� ����
                        Destroy(gameObject, 3.0f); //�������� �� �� ����̴� 3�� ��(ȭ��ۿ� ������ �ð�)�� �������.
                        GameManager.Instance.AddScroe(); //�������� �� �� ����̿��� �¾Ƶ� score�� ������. �׷��� isFull�� false�϶��� ����� �� �ֵ��� �Ѵ�.
                    }
                }
            }
        }
    }
}
