using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private int _maxSpringValue;
    [SerializeField] private Rigidbody _spoon;
    [SerializeField] private SpringJoint _joint;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Collider _reloadCollider;
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private KeyCode _launchKey;
    [SerializeField] private KeyCode _resetKey;

    private void Update()
    {
        if (Input.GetKeyDown(_launchKey))
        {
            Launch();
        }

        if (Input.GetKeyDown(_resetKey))
        {
            Reset();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == _reloadCollider)
            Instantiate(_cubePrefab, _spawnPoint.transform.position, Quaternion.identity);
    }

    private void Launch()
    {
        _spoon.AddForce(Vector3.up * 0.1f, ForceMode.Impulse);
        _joint.spring = _maxSpringValue;
    }

    private void Reset()
    {
        _spoon.AddForce(Vector3.down * 0.1f, ForceMode.Impulse);
        _joint.spring = 0;
    }
}
