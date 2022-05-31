using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    float mouseSensitivity;
    float currentCameraRotationX = 0;
    float currentCameraRotationY = 0;
    [SerializeField]
    float speed;
    [SerializeField]
    Camera camera_Main;
    [SerializeField]
    Text EnterText;
    int selectedStage = 0;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // 마우스 커서 숨기기
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        MouseRotation();
        KeyboardInput();
    }
    void KeyboardInput() // 사용자입력
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            transform.position = new Vector3(transform.position.x, 8.3f, transform.position.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            transform.position = new Vector3(transform.position.x, 8.3f, transform.position.z);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, 8.3f, transform.position.z);

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, 8.3f, transform.position.z);
        }
        if (Input.GetKey(KeyCode.E) && selectedStage != 0)
        {
            // 씬전환 시 데이터전환 설계 전 임시 씬전환 
            GameManager.gameManager.currentStage = selectedStage;
            SceneManager.LoadScene("2DMain");
        }
    }
    void MouseRotation() // 마우스 이동에 따른 카메라 rotate
    {
        float yRotation = Input.GetAxisRaw("Mouse X");
        float cameraRotationY = yRotation * mouseSensitivity;
        currentCameraRotationY -= cameraRotationY;

        float xRotation = Input.GetAxisRaw("Mouse Y");
        float cameraRotationX = xRotation * mouseSensitivity;
        currentCameraRotationX -= cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -75f, 75f);

        camera_Main.transform.position = transform.position;        

        camera_Main.transform.localEulerAngles = new Vector3(currentCameraRotationX, -currentCameraRotationY, 0f);
        transform.localEulerAngles = camera_Main.transform.localEulerAngles;
    }
    private void OnTriggerEnter(Collider other) // 오락기 충돌
    {        
        if(other.tag == "Stage1" || other.tag == "Stage2" || other.tag == "Stage3") // 오락기 충돌시 텍스트 제어
        {
            EnterText.gameObject.SetActive(true);
            EnterText.text = "E를눌러 진입 (" + other.tag + ")";
            if (other.tag == "Stage1") selectedStage = 1;
            else if (other.tag == "Stage2") selectedStage = 2;
            else if (other.tag == "Stage3") selectedStage = 3;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Stage1" || other.tag == "Stage2" || other.tag == "Stage3")
        {
            EnterText.gameObject.SetActive(false);
            selectedStage = 0;
        }
    }
}