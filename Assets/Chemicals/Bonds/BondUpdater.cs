using UnityEngine;

public class BondUpdater : MonoBehaviour
{
    public GameObject atomA;
    public GameObject atomB;

    void LateUpdate() {
        if (atomA == null || atomB == null) return;

        Vector3 posA = atomA.transform.position;
        Vector3 posB = atomB.transform.position;

        // Position
        transform.position = (posA + posB) / 2f;

        // Rotation
        Vector3 dir = posB - posA;
        transform.up = dir.normalized;

        // Scale
        transform.localScale = new Vector3(
            atomA.transform.lossyScale.x * 0.006f,
            dir.magnitude / 2f,
            atomA.transform.lossyScale.z * 0.006f
        );
    }
}
