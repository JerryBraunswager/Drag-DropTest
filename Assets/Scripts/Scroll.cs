using UnityEngine;

public class Scroll : MonoBehaviour
{
    [SerializeField] private float _maxX = 20.58f;

    private void Update()
    {
        transform.Translate(Vector3.right * Input.GetAxis("Mouse ScrollWheel"));
        float x = Mathf.Clamp(transform.position.x, -_maxX, _maxX);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
