using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Rigidbody))]
public class Swing : MonoBehaviour
{
    [SerializeField] private float _swingForce;
    [SerializeField] private GameObject _directionObject;

    private Rigidbody _cubeRigidBody;

    private void Awake()
    {
        _cubeRigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space pressed");

            Vector3 direction = _directionObject.transform.position - transform.position;
            direction = direction.normalized;

            _cubeRigidBody.AddForce(direction * _swingForce, ForceMode.Impulse);
        }
    }
}
