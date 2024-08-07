using System.Collections;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    public int maxSpring;
    public Transform spoon;
    public SpringJoint joint;
    public Vector3 resetPosition;
    public Rigidbody projectilePrefab;
    public Transform projectileSpawnPosition;

    private bool _isRestart = false;
    private bool _isLaunch = false;

    private void Awake()
    {
        resetPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isRestart == false)
        {
            LaunchCatapult();
        }

        if (Input.GetKeyDown(KeyCode.R) && _isRestart == false)
        {
            ResetCatapult();
        }
    }

    private void ResetCatapult()
    {
        joint.spring = 0;

        StartCoroutine(Reset());
    }

    private void LaunchCatapult()
    {
        joint.spring = maxSpring;
    }

    private IEnumerator Reset()
    {
        _isRestart = true;
        bool isWork = true;

        while (isWork)
        {
            if (spoon.transform.position != resetPosition)
            {
                isWork = false;
                Instantiate(projectilePrefab, projectileSpawnPosition.position, projectileSpawnPosition.rotation);
                _isRestart = false;
            }

            yield return null;
        }
    }
}