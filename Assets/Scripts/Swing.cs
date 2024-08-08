using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Swing : MonoBehaviour
{
    [SerializeField] private float _swingForce;
    [SerializeField] private GameObject _directionObject;
    [SerializeField] private KeyCode _swingKey;

    private Rigidbody _cubeRigidBody;

    private void Awake()
    {
        _cubeRigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_swingKey))
        {
            Debug.Log("Space pressed");

            Vector3 direction = _directionObject.transform.position - transform.position;
            direction = direction.normalized;

            _cubeRigidBody.AddForce(direction * _swingForce, ForceMode.Impulse);
        }
    }
}
