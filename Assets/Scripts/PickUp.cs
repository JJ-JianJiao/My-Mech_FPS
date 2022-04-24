using UnityEngine;

public class PickUp: MonoBehaviour
{

    [Tooltip("Frequency at which the item will move up and down")]
    public float VerticalBobFrequency = 1f;

    [Tooltip("Distance the item will move up and down")]
    public float BobbingAmount = 1f;

    private float RotateSpeed = 300;
    public Rigidbody PickupRigidbody { get; private set; }
    Collider m_Collider;
    Vector3 m_StartPosition;
    protected virtual void Start()
    {
        PickupRigidbody = GetComponent<Rigidbody>();
        m_Collider = GetComponent<Collider>();

        PickupRigidbody.isKinematic = true;
        m_Collider.isTrigger = true;

        // Remember start position for animation
        m_StartPosition = transform.position;
    }

    protected virtual void Update() {

        float bobbingAnimationPhase = ((Mathf.Sin(Time.time * VerticalBobFrequency) * 0.5f) + 0.5f) * BobbingAmount;
        transform.position = m_StartPosition + Vector3.up * bobbingAnimationPhase;
        transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime, Space.Self);
    }



}