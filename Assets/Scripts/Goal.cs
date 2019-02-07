using UnityEngine;

public class Goal : MonoBehaviour
{
    private PongManager _gameManager;

    [SerializeField]
    public string PointReceiver = "";

    private void Start()
    {
        _gameManager = GetComponentInParent<PongManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Ball" && PointReceiver != "")
        {            
            _gameManager.PlayerScored(PointReceiver);
        }
    }
}
