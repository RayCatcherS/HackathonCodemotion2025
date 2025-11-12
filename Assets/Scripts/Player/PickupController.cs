using UnityEngine;

public class PickupController : MonoBehaviour
{   
    [Header("Pickup Settings")]
    [SerializeField] private Transform holdArea;          // Un empty davanti alla camera (figlio della camera)
    [SerializeField] private float pickupRange = 5f;      // Distanza massima per il raycast
    [SerializeField] private LayerMask pickableMask;      // Lascia vuoto per tutti i layer

    [Header("Keybinds")]
    [SerializeField] private KeyCode pickUpKey = KeyCode.Space;


    [Header("Follow (Translation)")]
    [SerializeField] private float followForce = 25f;     // Forza/guadagno verso l'holdArea
    [SerializeField] private float maxCarrySpeed = 12f;   // Velocità max quando lo tieni

    [Header("Follow (Rotation)")]
    [SerializeField] private float rotationGain = 15f;    // Guadagno rotazionale (torque virtuale)
    [SerializeField] private float maxAngularSpeed = 20f; // Limite velocità angolare (rad/s)

    [Header("Carried Rigidbody Settings")]
    [SerializeField] private float carryDrag = 10f;
    [SerializeField] private float carryAngularDrag = 10f;

    private GameObject heldObj;
    private Rigidbody heldObjRB;
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
        if (!cam) Debug.LogWarning("PickupController: nessuna Camera.main trovata.");
        if (!holdArea) Debug.LogWarning("PickupController: assegna un 'holdArea' (figlio della camera).");
    }

    private void Update()
    {


        if (Input.GetKeyDown(pickUpKey))
        {
            if (heldObj == null) TryPickup();
            else DropObject();
        }
    }

    private void FixedUpdate()
    {
        if (heldObjRB != null)
        {
            PhysicsFollow();
        }
    }

    private void TryPickup()
    {
        if (!cam) return;

        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f));
        if (Physics.Raycast(ray, out var hit, pickupRange, (pickableMask.value == 0) ? ~0 : pickableMask))
        {
            var rb = hit.rigidbody;
            if (rb != null)
            {
                PickupObject(rb.gameObject);
            }
        }
    }

    private void PickupObject(GameObject pickObj)
    {
        if (!pickObj.TryGetComponent<Rigidbody>(out var rb)) return;

        heldObj = pickObj;
        heldObjRB = rb;

        // Config dinamica “in mano”
        heldObjRB.useGravity = false;
        heldObjRB.linearDamping = carryDrag;
        heldObjRB.angularDamping = carryAngularDrag;
        heldObjRB.constraints = RigidbodyConstraints.None; // deve poter ruotare
        heldObjRB.collisionDetectionMode = CollisionDetectionMode.Continuous;
        heldObjRB.interpolation = RigidbodyInterpolation.Interpolate;
        heldObjRB.maxAngularVelocity = Mathf.Max(heldObjRB.maxAngularVelocity, maxAngularSpeed * Mathf.Rad2Deg); // Unity usa gradi/s internamente
    }

    private void PhysicsFollow()
    {
        if (!holdArea) return;

        // --- Traslazione: avvicina con “forza/velocità target” ---
        Vector3 toTarget = holdArea.position - heldObjRB.position;
        Vector3 desiredVel = toTarget * followForce;
        desiredVel = Vector3.ClampMagnitude(desiredVel, maxCarrySpeed);
        heldObjRB.linearVelocity = desiredVel;

        // --- Rotazione: allinea a holdArea.rotation usando velocità angolare target ---
        // Calcola la differenza di rotazione (quaternion delta)
        Quaternion targetRot = holdArea.rotation;
        Quaternion delta = targetRot * Quaternion.Inverse(heldObjRB.rotation);
        delta.ToAngleAxis(out float angleDeg, out Vector3 axis);
        if (float.IsNaN(axis.x)) return; // sicurezza contro numeri strani

        // Porta l'angolo in [0, 180]
        if (angleDeg > 180f) angleDeg -= 360f;

        // Se l'angolo è molto piccolo, azzera lentamente l'ang vel
        if (Mathf.Abs(angleDeg) < 0.5f)
        {
            heldObjRB.angularVelocity = Vector3.Lerp(heldObjRB.angularVelocity, Vector3.zero, 0.5f);
            return;
        }

        // Velocità angolare desiderata (rad/s) proporzionale all'errore
        float angleRad = angleDeg * Mathf.Deg2Rad;
        Vector3 desiredAngVel = axis.normalized * angleRad * rotationGain;

        // Clampa e applica
        if (desiredAngVel.magnitude > maxAngularSpeed)
            desiredAngVel = desiredAngVel.normalized * maxAngularSpeed;

        // Porta l'ang vel attuale verso la desiderata (smorzamento)
        heldObjRB.angularVelocity = Vector3.Lerp(heldObjRB.angularVelocity, desiredAngVel, 0.5f);
    }

    private void DropObject()
    {
        if (heldObjRB == null)
        {
            heldObj = null;
            return;
        }

        // Ripristina fisica “normale”
        heldObjRB.useGravity = true;
        heldObjRB.linearDamping = 0f;
        heldObjRB.angularDamping = 0.05f;
        heldObjRB.constraints = RigidbodyConstraints.None;

        heldObj = null;
        heldObjRB = null;
    }

    private void OnDisable()
    {
        if (heldObjRB != null) DropObject();
    }
}
