using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private const int PlayerSpeed = 10;

    private int _shots;

    private float _mouseLookH;
    private float _mouseLookV;

    [SerializeField]
    private Ball _ball;

    private GameObject _playerCamera;
    
    private Text _shotsText;

    private void Start()
    {
        _playerCamera = GameObject.FindGameObjectWithTag("MainCamera");

        _shotsText = GameObject.FindGameObjectWithTag("Shots").GetComponent<Text>();
        
        UpdateShotText();
    }

    private void Update()
    {
        HandleInput();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.name.Equals("Ball")) return;
        if (_shots < 5)
        {
            _shots++;
        }
        UpdateShotText();
    }

    private void UpdateShotText()
    {
        _shotsText.text = "Shots: " + _shots;
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
        
        _mouseLookH += Input.GetAxisRaw("Mouse X");
        _mouseLookV += Input.GetAxisRaw("Mouse Y");

        if (_mouseLookH >= -20.0f && _mouseLookH <= 20.0f)
        {
            _playerCamera.transform.localRotation = Quaternion.AngleAxis(_mouseLookH, _playerCamera.transform.up);
        }

        //doesnt quite work yet, need better clamping for vertical camera movement
        if (_mouseLookV >= -10.0f && _mouseLookV <= 10.0f)
        {
            _playerCamera.transform.localRotation = Quaternion.AngleAxis(_mouseLookV, _playerCamera.transform.right);
        }

        if (Input.GetButtonDown("Fire1") && _playerCamera != null && _shots > 0)
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(_playerCamera.transform.position, _playerCamera.transform.forward, out raycastHit, 30.0f))
            {
                if (raycastHit.transform.name.Equals("Ball"))
                {
                    FireShot();
                }
            }

            _shots--;
        }
    }

    private void FireShot()
    {
        if (_ball == null) return;
        
        Debug.Log("Hit the ball");
        _ball.HasBeenShot(_playerCamera.transform.forward);
    }
}
