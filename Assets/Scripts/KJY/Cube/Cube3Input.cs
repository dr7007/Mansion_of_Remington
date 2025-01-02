using TMPro;
using UnityEngine;

public class Cube3Input : MonoBehaviour
{

    public TMP_Text text2;  // TMP_Text 컴포넌트를 연결

    private int currentValue = 0; // 숫자의 비트값 (초기값 0000)

    public bool TheCube3Result = false;

    private void Start()
    {
        text2.text = "0000";
    }

    private void Update()
    {
        // 각 키 입력에 따라 해당 자리값만 증가
        if (Input.GetKeyDown(KeyCode.Q))
        {
            IncrementValue(1000);  // Q 키는 첫 번째 자리 증가
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            IncrementValue(0100);  // W 키는 두 번째 자리 증가
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            IncrementValue(0010);  // E 키는 세 번째 자리 증가
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            IncrementValue(0001);  // R 키는 네 번째 자리 증가
        }
    }

    // 지정된 자리에 해당하는 값을 증가시키는 함수
    private void IncrementValue(int positionValue)
    {
        // 각 자리를 독립적으로 증가시키기 위해 각 자리의 숫자를 추출
        int thousands = (currentValue / 1000) % 10; // 첫 번째 자리 (1000 자리)
        int hundreds = (currentValue / 100) % 10;   // 두 번째 자리 (100 자리)
        int tens = (currentValue / 10) % 10;        // 세 번째 자리 (10 자리)
        int ones = currentValue % 10;               // 네 번째 자리 (1 자리)

        // positionValue에 따라 해당 자리 값을 증가시킴
        if (positionValue == 1000)
        {
            thousands = (thousands + 1) % 10; // 첫 번째 자리 증가
        }
        else if (positionValue == 0100)
        {
            hundreds = (hundreds + 1) % 10;  // 두 번째 자리 증가
        }
        else if (positionValue == 0010)
        {
            tens = (tens + 1) % 10;          // 세 번째 자리 증가
        }
        else if (positionValue == 0001)
        {
            ones = (ones + 1) % 10;          // 네 번째 자리 증가
        }

        // 새로운 값을 합쳐서 currentValue로 설정
        currentValue = thousands * 1000 + hundreds * 100 + tens * 10 + ones;

        // 텍스트를 4자리 숫자로 표시 (예: 0000, 1000, 0100)
        text2.text = currentValue.ToString("D4");
    }

}
