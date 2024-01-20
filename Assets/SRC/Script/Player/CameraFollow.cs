using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform _player; // Посилання на трансформ гравця
    public Vector3 _offset; // Зсув камери відносно гравця

    private void Update()
    {
        if (_player != null)
        {
            transform.position = _player.position + _offset;
        }
    }
}
