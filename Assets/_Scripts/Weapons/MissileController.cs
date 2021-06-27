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
            Vector3 targetPosition = target ? target.position : new Vector3(0f, 0f, 0f);
            missileRigidbody.velocity = missileTransform.forward * speed;
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition - missileTransform.position);
            missileRigidbody.MoveRotation(Quaternion.RotateTowards(missileTransform.rotation, targetRotation, rotateSpeed));
        }
    }
}
