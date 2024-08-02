using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class newbuttoncontrol : MonoBehaviour
{
    // 버튼 이벤트 스크립트 : 이제 이거 써요
    public talkwithjjang_yj talkScript_yj;
    public Button noButton1; // 아니오 버튼 연결1
    public Button noButton2; // 아니오 버튼 연결2
    public Button noButton3; // 아니오 버튼 연결3
    public Button noButton4; // 아니오 버튼 연결4

    // 기본 활동 버튼들
    public Button trainingButton_yj; // 1. 훈련 시도 버튼 연결
    public Button campingButton_yj; // 2. 단합 시도 버튼 연결
    public Button findhintButton_yj; // 3. 단서 보기 버튼 연결
    public Button laybedButton_yj; // 4. 휴식하기 버튼 연결4

    // 버튼 누르면 각각 나오는 패널들 
    public GameObject trainingUI_yj; // 훈련 중 패널
    public GameObject campingUI_yj; // 단합 중 패널
    public GameObject iaminbedUI_yj; // 휴식 UI 패널
    
    public GameObject resultUI_yj; // 결과 UI 패널

    private bool isworking_yj = true; // 현재 진행중인지 알아보는 함수

    public void Start()
    {
       // talkScript_yj = GetComponent<talkwithjjang_yj>();
        trainingButton_yj.onClick.AddListener(OntrainButtonClick);
        campingButton_yj.onClick.AddListener(OncampButtonClick);
        //findhintButton_yj.onClick.AddListener(OnhintButtonClick);
        laybedButton_yj.onClick.AddListener(OnbedButtonClick);

        noButton1.onClick.AddListener(OnNo1ButtonClick);
        noButton2.onClick.AddListener(OnNo2ButtonClick);
        noButton3.onClick.AddListener(OnNo3ButtonClick);
        noButton4.onClick.AddListener(OnNo4ButtonClick);
    }

    // 기본활동1 : "훈련한다" 선택했을 때
    public void OntrainButtonClick()
    {
        if(talkScript_yj.Dial_changyj.activeSelf)
        {
            talkScript_yj.Dial_changyj.SetActive(false);
            talkScript_yj.choiceUI1_yj.SetActive(false);
            resultUI_yj.SetActive(true);
            Invoke("DisableResultUI_yj", 3f);
        }
    }

    // 기본활동2 : 단합한다 했을 때
    public void OncampButtonClick()
    {
        talkScript_yj.choiceUI2_yj.SetActive(false); // 선택 UI 비활성화
        campingUI_yj.SetActive(true);// 단합 UI 표시(3초간 지속)
        Invoke("DisablecampUI_yj", 3f); // 3초 후에 단합 UI를 자동으로 비활성화 처리하는 메서드 
        resultUI_yj.SetActive(true);// 결과 창 표시 (성공UI, 1,2 동시 사용)
        talkScript_yj.nowplayer_yj.team_py++; // 단합변수 1 증가
        talkScript_yj.nowplayer_yj.howtoday_py++; // 하루 기본 활동 수행 횟수 1 증가
        Invoke("DisableResultUI_yj", 3f); // 3초 후에 결과 UI를 자동으로 비활성화 처리하는 메서드 호출
    }
    // 기본활동3 : 단서 보겠다 했을 때
    /*public void OnhintButtonClick()
    {
        talkScript_yj.choiceUI3_yj.SetActive(false);
        SceneManager.LoadScene("InventoryMain"); // 인벤토리 씬으로 이동
        // 찾은 단서 개수를 한 개 늘림. 이건 인벤토리랑 연관 후에 생각해야 할듯
    }*/
    // 기본활동4 : 휴식 취하겠다 했을 때
    public void OnbedButtonClick()
    {
        talkScript_yj.choiceUI4_yj.SetActive(false);
        iaminbedUI_yj.SetActive(true); // 휴식 UI 띄우기
        Invoke("DisablebedUI_yj", 3f); // 3초 후에 결과 UI를 자동으로 비활성화 처리하는 메서드 호출
        talkScript_yj.nowplayer_yj.howtoday_py++; // 하루 기본 활동 수행 횟수 1 증가
    }

    public void OnNo1ButtonClick()
    {
        talkScript_yj.choiceUI1_yj.SetActive(false); // 훈련 UI 선택창 비활성화 
    }
    public void OnNo2ButtonClick()
    {
        talkScript_yj.choiceUI2_yj.SetActive(false); // 단합 UI 선택창 비활성화
    }
    public void OnNo3ButtonClick()
    {
        talkScript_yj.choiceUI3_yj.SetActive(false); // 단서 UI 선택창 비활성화
    }
    public void OnNo4ButtonClick()
    {
        talkScript_yj.choiceUI4_yj.SetActive(false); // 휴식 UI 선택창 비활성화
    }
    // 1. 훈련중 UI 띄움
    void OnTrainUItrue_yj() {
        // 훈련 버튼 클릭 시 훈련 UI만 활성화하고 다른 UI 비활성화
        trainingUI_yj.SetActive(true);
        campingUI_yj.SetActive(false);
        resultUI_yj.SetActive(false);
        talkScript_yj.choiceUI1_yj.SetActive(false);
    }

    // 1. 훈련중 UI를 비활성화시키고 성공 창을 띄움
    void OnResulUItrue1_yj()
    {
        talkScript_yj.Dial_changyj.SetActive(false);
        talkScript_yj.choiceUI1_yj.SetActive(false);
        trainingUI_yj.SetActive(false); // Deactivate training UI
        resultUI_yj.SetActive(true); // Activate result UI

    }

    // 2. 단합중 UI를 비활성화시키고 성공 창을 띄움
    void OnResulUItrue2_yj()
    {
        talkScript_yj.Dial_changyj.SetActive(false);
        campingUI_yj.SetActive(false); // Deactivate training UI
        resultUI_yj.SetActive(true); // Activate result UI
    }

    void DisableResultUI_yj()
    {
        resultUI_yj.SetActive(false);

        // Reset flags and UI states
        isworking_yj = true;
        trainingUI_yj.SetActive(false);
        talkScript_yj.choiceUI1_yj.SetActive(false);
    }
    void DisabletrainUI_yj()
    {
        trainingUI_yj.SetActive(false);
    }
    void DisablecampUI_yj()
    {
        campingUI_yj.SetActive(false);
    }
    void DisablebedUI_yj()
    {
        iaminbedUI_yj.SetActive(false);
    }
}
