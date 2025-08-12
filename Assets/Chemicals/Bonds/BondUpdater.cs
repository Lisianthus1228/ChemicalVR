using UnityEngine;

public class BondUpdater : MonoBehaviour
{
    public Transform atomA;
    public Transform atomB;

    void LateUpdate() {
        if (atomA == null || atomB == null) return;

        Vector3 posA = atomA.position;
        Vector3 posB = atomB.position;

        // Position
        transform.position = (posA + posB) / 2f;

        // Rotation
        Vector3 dir = posB - posA;
        transform.up = dir.normalized;

        // Scale
        transform.localScale = new Vector3(
            transform.localScale.x,
            dir.magnitude / 2f,
            transform.localScale.z
        );
    }
}
