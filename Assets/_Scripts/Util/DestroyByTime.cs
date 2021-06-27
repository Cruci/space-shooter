using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    public GameObject objectToDestroy;
    public float lifetime;

    private void Start()
    {
        if (objectToDestroy.transform.parent)
        {
            Destroy(objectToDestroy.transform.parent.gameObject, lifetime);
        }
        else
        {
            Destroy(objectToDestroy, lifetime);

        }
    }
}
