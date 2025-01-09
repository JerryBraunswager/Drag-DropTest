using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Drag : MonoBehaviour
{
    private bool _isDragging = false;
    private Transform _parent;
    private Rigidbody2D _attachedRigidbody;

    private void Awake()
    {
        _attachedRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(_isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition;
        }
    }

    private void OnMouseDown()
    {
        _parent = transform.parent;
        transform.parent = transform.parent.parent;
        _isDragging = true;
        _attachedRigidbody.gravityScale = 1;
    }

    private void OnMouseUp()
    {
        transform.parent = _parent;
        _isDragging = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _attachedRigidbody.gravityScale = 0;
        _attachedRigidbody.velocity = Vector2.zero;
    }
}
