using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class PlayerMovement : MonoBehaviour
{
    public Transform[] _points;
    private Transform _playerTransform;

    public Image _diceImg;
    public Sprite[] _dice;
    public Button _but;
    public static string _contact = "";

    private int _posNow = 0;
    public float _moveSpeed = 5f;

    private void Start()
    {
        _playerTransform = GetComponent<Transform>();
    }

    public void movePlayer()
    {
        StartCoroutine(movePlayerLogic());
    }

    public IEnumerator movePlayerLogic()
    {
        int randomNumber = Random.Range(1, 7);
        Debug.Log(randomNumber);

        _but.interactable = false;
        _diceImg.gameObject.SetActive(true);
        _diceImg.sprite = _dice[randomNumber - 1];

        int targetPos = (_posNow + randomNumber) % _points.Length; // Визначаємо цільову позицію

        // Переміщення між початковою та цільовою позиціями зі швидкістю moveSpeed
        while (_posNow != targetPos)
        {
            _posNow = (_posNow + 1) % _points.Length; // Переміщуємося наступну позицію
            float step = _moveSpeed * Time.deltaTime; // Визначаємо відстань, яку ми рухаємось за кожен кадр
            Vector3 targetPosition = _points[_posNow].position; // Визначаємо цільову позицію

            // Переміщуємо гравця до цільової позиції зі швидкістю moveSpeed
            while (_playerTransform.position != targetPosition)
            {
                _playerTransform.position = Vector3.MoveTowards(_playerTransform.position, targetPosition, step); // Застосовуємо переміщення гравця зі швидкістю moveSpeed

                // Очікуємо до наступного кадру
                yield return null;
            }

            // Затримка між етапами переміщення
            yield return new WaitForSeconds(0.5f); // Затримка на 0.5 секунди між кожним етапом переміщення
        }

        // Тепер гравець знаходиться на цільовій позиції

        if (_points[_posNow])
        {
            Debug.Log(_points[_posNow].name);
            Debug.Log("Гравець знаходиться на позиції: " + _posNow);
        }
        
        _contact = _points[_posNow].name;
        _but.interactable = true;
        _diceImg.gameObject.SetActive(false);
    }
}
