using UnityEngine;
using UnityEngine.UI;

public class randomImage : MonoBehaviour
{
    public Sprite[] _imgSprites;
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
        int randomNumber = Random.Range(0, _imgSprites.Length);
        _image.sprite = _imgSprites[randomNumber];
    }
}
