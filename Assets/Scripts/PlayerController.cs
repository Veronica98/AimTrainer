using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;



public class PlayerController : MonoBehaviour
{
    public float horizontalInput, verticalInput;
    public float movementSpeed = 8f;
    public Transform body;

    private Transform cameraTransform;
    float xRotation = 0f;

    public CharacterController characterController;
    GenerateTargets TargetSpawner;
    GameObject targetScript;
    Camera mouseCamera;
    AudioSource audioSource;
    [SerializeField] private Transform CentralWall;
    public GameSettings GameSettings;




    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GameSettings = GameObject.Find("GameSettings").GetComponent<GameSettings>();
        Cursor.lockState = CursorLockMode.Locked;
        cameraTransform = GameObject.Find("Main Camera").transform;
        cameraTransform.LookAt(CentralWall);
        mouseCamera = Camera.main;
        targetScript = GameObject.Find("TargetSpawner");
        TargetSpawner = targetScript.GetComponent<GenerateTargets>();
    }

    void Update()
    {
        float playerCameraX = Input.GetAxis("Mouse X") * GameSettings.mouseSensitivity * Time.deltaTime;
        float playerCameraY = Input.GetAxis("Mouse Y") * GameSettings.mouseSensitivity * Time.deltaTime;

        body.Rotate(Vector3.up * playerCameraX);
        xRotation -= playerCameraY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = transform.right * horizontalInput + transform.forward * verticalInput;
        characterController.Move(movementDirection * movementSpeed * Time.deltaTime);

        if(Input.GetMouseButtonDown(0))
        {
            Vector3 getMousePos = Input.mousePosition;
            Ray raycast = mouseCamera.ScreenPointToRay(getMousePos);
            if(Physics.Raycast(raycast, out RaycastHit hit) && Time.timeScale != 0)
            {
                if (hit.collider.gameObject.CompareTag("Target"))
                {
                    Object.Destroy(hit.collider.gameObject);
                    audioSource.Play();
                    GameSettings.noOfTargets++;
                    GameSettings.score += 100;
                    GameSettings.targetsHit++;
                    TargetSpawner.GenerateStaticTargets(1);
                }
                else if (hit.collider.gameObject.CompareTag("MovingTarget"))
                {
                    Object.Destroy(hit.collider.gameObject);
                    audioSource.Play();
                    GameSettings.noOfTargets++;
                    GameSettings.score += 100;
                    GameSettings.targetsHit++;
                    TargetSpawner.GenerateMovingTarget(1);
                }
                else if(hit.collider.gameObject.CompareTag("DecreasingTarget"))
                {
                    Object.Destroy(hit.collider.gameObject);
                    audioSource.Play();
                    GameSettings.noOfTargets++;
                    GameSettings.score += 100;
                    GameSettings.targetsHit++;
                    TargetSpawner.GenerateDecreasingTargets(1);
                }
                else 
                {
                    GameSettings.missedShots++;
                }
            } 
        }
    }
}
