using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Square : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-3f, 3f); //������ �� �ִ� �ּ� x ��ġ���� �ִ� x ��ġ��
        float y = Random.Range(3.0f, 5.0f); //������ �� �ִ� �ּ� y ��ġ���� �ִ� y ��ġ��

        transform.position = new Vector3 (x, y, 0); //����Ƽ transform-Position�� ������ x,y�� �Է�

        float size = Random.Range(0.5f, 1.5f); //������ ũ���� Square ����
        transform.localScale = new Vector2(size, size); //����Ƽ Transform-Scale�� ������ size �Է�

    }

    // Update is called once per frame
    void Update()
    {

    }

    /* ���� : �������� �׸� ���ֱ�
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    */

    public void OnCollisionEnter2D(Collision2D collision) //collision(�浹)�� ������Ʈ �߿���
    {
        if (collision.gameObject.CompareTag("Player")) //�±װ� Player���� �˻�
        {
            GameManager.instance.GameOver();
        }
    }
}
