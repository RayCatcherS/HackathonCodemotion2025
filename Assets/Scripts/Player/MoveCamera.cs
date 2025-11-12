using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;
    void Update()
    {
        // si può usare un lerp per rendere il movimento più fluido ma per ora va bene così
        transform.position = cameraPosition.position;
    }
}
