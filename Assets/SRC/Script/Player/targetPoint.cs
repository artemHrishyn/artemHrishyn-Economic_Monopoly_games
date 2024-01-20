using UnityEngine;

public class targetPoint : MonoBehaviour
{
    public GameObject _images;
    public GameObject _random;
    public GameObject _deal;
    public GameObject _casino;

    // Update is called once per frame
    void Update()
    {
        switch (PlayerMovement._contact)
        {
            case "deal":
                _deal.SetActive(true);
                break;

            case "image":
                _images.SetActive(true);
                break;

            case "ñasino":
                _casino.SetActive(true);
                break;

            case "random":
                _random.SetActive(true);
                break;
            case "vacation":
                Debug.Log("vacation");
                break;
            case "bad PR":
                Debug.Log("bad PR");
                break;

            case "salary":
                Debug.Log("salary");
                break;
            default:
                break;
        }
    }
    
    public void Close()
    {
        PlayerMovement._contact = "";
        _images.SetActive(false);
        _deal.SetActive(false);
        _random.SetActive(false);
        _casino.SetActive(false);
    }
}
