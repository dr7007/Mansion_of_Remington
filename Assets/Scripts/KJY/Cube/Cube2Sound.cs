using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class Cube2Sound : MonoBehaviour
{

    public AudioClip DogSound;
    public AudioClip MouseSound;
    public AudioClip RabbitSound;
    public AudioClip MonkeySound;
    public AudioClip AnimalPlay;

    //성공 & 실패 효과음
    public AudioClip success;
    public AudioClip failure; 

    //정답
    private string[] Result = { "dog", "monkey", "dog", "mouse", "rabbit" };
    private string[] InputResult = new string[5];


    private GameObject[] Lights = new GameObject[5];
    [SerializeField] private Transform[] LightsPos;
    [SerializeField] private GameObject GreenLight;

   
    private int curNum = 0;

    //기자방의 버튼상태 전달받기
    public int Rabbit = 0;
    public int Monkey = 0;

    //결과값
    public bool TheCube2Result = false;


    private void Update()
    {
        if (curNum < 5)
        {
            CheckAnimal();
            TheOtherAnimalValue();
        }
        else if (curNum == 5)
            FinalCheck();

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "AnimalPlayButton")
                {
                    AudioClip AnimalPlaySound = AnimalPlay;
                    GetComponent<AudioSource>().Stop();
                    GetComponent<AudioSource>().PlayOneShot(AnimalPlaySound, 0.8f);
                }
            }
        }
    }


    private void CheckAnimal()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "Dog")
                {
                    AddLight();
                    //DogLight.gameObject.SetActive(true);
                    Debug.Log("Doglight");
                    AudioClip AnimalSound = DogSound;
                    GetComponent<AudioSource>().Stop();
                    GetComponent<AudioSource>().PlayOneShot(AnimalSound, 0.8f);

                    AddToArr("dog");
                }
                if (hit.transform.gameObject.tag == "Mouse")
                {
                    AddLight();
                    //MouseLight.gameObject.SetActive(true);
                    AudioClip AnimalSound = MouseSound;
                    GetComponent<AudioSource>().Stop();
                    GetComponent<AudioSource>().PlayOneShot(AnimalSound, 0.8f);

                    AddToArr("mouse");
                }
            }

        }
       // yield return null;
    }


    private void AddToArr(string _animal)
    {
        for (int i = 0; i < InputResult.Length; ++i)
        {
            if (InputResult[i] == null)
            {
                //빈 칸에 값을 넣기
                InputResult[i] = _animal;
                Debug.Log($"{_animal}이(가) 배열의 {i}번 칸에 추가되었습니다.");
                return;
            }
        }
    }

    private void AddLight()
    {
        //GameObject greenLightInstance = Instantiate(GreenLight, LightsPos[curNum].position, Quaternion.Euler(0f,90f,0f));

        if (curNum < Lights.Length && Lights[curNum] == null)
        {
            Lights[curNum] = Instantiate(GreenLight, LightsPos[curNum].position, Quaternion.Euler(0f, 90f, 0f));

            //greenLightInstance.transform.SetParent(Lights[curNum].transform);
            curNum++;
        }
    }

    //판정하는 시기 생각하기
    private void CheckTheResult()
    {
        for (int i = 0; i < Result.Length; ++i)
        {
            if (Result[i] == InputResult[i])
            {
                TheCube2Result = true;
                AudioClip SuccessSound = success;
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().PlayOneShot(SuccessSound, 0.8f);
                curNum = 10;
                //DogLight.gameObject.SetActive(false);
            }
            else
            {
                AudioClip FailureSound = failure;
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().PlayOneShot(FailureSound, 0.8f);
                Debug.Log("실패");

                Destroy(Lights[0]);
                Destroy(Lights[1]);
                Destroy(Lights[2]);
                Destroy(Lights[3]);
                Destroy(Lights[4]);

                curNum = 0;


            }
        }
    }

    private void TheOtherAnimalValue()
    {
        if (Rabbit == 1)
        {
            //RabbitLight.gameObject.SetActive(true);
            AddLight();
            AudioClip AnimalSound = RabbitSound;
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().PlayOneShot(AnimalSound, 0.8f);

            AddToArr("rabbit");
        }
        if (Monkey == 1)
        {
            //MonkeyLight.gameObject.SetActive(true);
            AddLight();
            AudioClip AnimalSound = MonkeySound;
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().PlayOneShot(AnimalSound, 0.8f);

            AddToArr("monkey");
        }
    }

    private void FinalCheck()
    {
        if(curNum == 5)
        {
            // 업데이트에서 계속 들어오면 안되기 때문에 하나 증가
            ++curNum;

            //CheckTheResult();
            StartCoroutine(CheckTheResultCoroutine());
        }
    }

    private IEnumerator CheckTheResultCoroutine()
    {
        yield return null;

        while (true)
        {
            if (Input.GetMouseButtonDown(0)) break;
            yield return null;
        }

        CheckTheResult();
    }
}
