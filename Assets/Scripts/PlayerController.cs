using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const int PlayerSpeed = 10;

    private float _mouseLook = 0.0f;

    private GameObject _playerCamera;

    private void Start()
    {
        _playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.right * PlayerSpeed * -1 * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * PlayerSpeed * Time.deltaTime;
        }
        
        _mouseLook += Input.GetAxisRaw("Mouse X");

        if (_mouseLook >= -20.0f && _mouseLook <= 20.0f)
        {
            _playerCamera.transform.localRotation = Quaternion.AngleAxis(_mouseLook, _playerCamera.transform.up);
        }
    }
}
