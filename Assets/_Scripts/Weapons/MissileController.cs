using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MissileController : MonoBehaviour
{
    public Transform target;
    public float speed = 10f;
    public float rotateSpeed = 1f;

    private Rigidbody missileRigidbody;
    private Transform missileTransform;
    private GameObject enemyObject;
    private Quaternion targetRotation;

    // Start is called before the first frame update
    private void Start()
    {
        missileRigidbody = GetComponent<Rigidbody>();
        missileTransform = GetComponent<Transform>();
        enemyObject = GameObject.FindGameObjectWithTag("Enemy");

        if (!enemyObject)
        {
            return;
        }

        target = enemyObject.transform;
    }

    private void FixedUpdate()
    {
        if (enemyObject && target && missileRigidbody)
        {
            Vector3 targetPosition = target.position;
            FindEnemyPosition(targetPosition);
        }

        if (!target && missileRigidbody)
        {
            FindNextEnemyPosition();
        }
    }

    private void FindNextEnemyPosition()
    {
        enemyObject = GameObject.FindGameObjectWithTag("Enemy");

        if (enemyObject)
        {
            Vector3 targetPosition = enemyObject.transform.position;
            FindEnemyPosition(targetPosition);
        }

        if (!enemyObject)
        {
            missileRigidbody.velocity = missileTransform.forward * speed;
        }
    }

    private void FindEnemyPosition(Vector3 targetPosition)
    {
        missileRigidbody.velocity = missileTransform.forward * speed;
        targetRotation = Quaternion.LookRotation(targetPosition - missileTransform.position);
        missileRigidbody.MoveRotation(Quaternion.RotateTowards(missileTransform.rotation, targetRotation, rotateSpeed));
    }
}
