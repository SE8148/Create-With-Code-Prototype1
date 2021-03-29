using UnityEngine;

public class SpinPropellerX : MonoBehaviour
{
    public float propellerRotationSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * propellerRotationSpeed);
    }
}
