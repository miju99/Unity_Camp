using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Scene을 불러오기 위한 패키지

public class RetryButton : MonoBehaviour
{
  public void Retry() //'EndPanel' 컴포넌트의 Onclick에서 사용할 함수 선언
    {
        SceneManager.LoadScene("MainScene");//Scene을 불러온다.
    }
}
