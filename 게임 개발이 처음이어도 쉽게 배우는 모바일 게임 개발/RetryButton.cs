using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Scene�� �ҷ����� ���� ��Ű��

public class RetryButton : MonoBehaviour
{
  public void Retry() //'EndPanel' ������Ʈ�� Onclick���� ����� �Լ� ����
    {
        SceneManager.LoadScene("MainScene");//Scene�� �ҷ��´�.
    }
}
