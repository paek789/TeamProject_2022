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
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // ���콺 Ŀ�� �����
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        MouseRotation();
        KeyboardInput();
    }
    void KeyboardInput() // ������Է�
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
        if (Input.GetKey(KeyCode.E))
        {
            // ����ȯ �� ��������ȯ ���� �� �ӽ� ����ȯ 
            SceneManager.LoadScene("2DMain");
        }
    }

    void MouseRotation() // ���콺 �̵��� ���� ī�޶� rotate
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
    private void OnTriggerStay(Collider other) // ������ �浹
    {        
        if(other.tag == "Stage1" || other.tag == "Stage2" || other.tag == "Stage3") // ������ �浹�� �ؽ�Ʈ ����
        {
            EnterText.gameObject.SetActive(true);
            EnterText.text = "E������ ���� (" + other.tag + ")"; 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Stage1" || other.tag == "Stage2" || other.tag == "Stage3")
        {
            EnterText.gameObject.SetActive(false);
        }
    }
}