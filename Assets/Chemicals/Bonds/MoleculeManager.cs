using System.Collections.Generic;
using UnityEngine;

public class MoleculeManager : MonoBehaviour
{
    public GameObject singleBondPrefab;
    public GameObject doubleBondPrefab;

    public List<Bond> bonds = new List<Bond>();
    private List<GameObject> spawnedBonds = new List<GameObject>();

    void Start() {
        SpawnBonds();
    }

    void SpawnBonds() {
        // Instantiate appropriate bond prefab with bond type and the 2 atoms they connect.
        foreach(var bond in bonds) {
            GameObject prefab = bond.bondType == BondType.Double ? doubleBondPrefab : singleBondPrefab;
            GameObject bondObj = Instantiate(prefab, transform);

            BondUpdater updater = bondObj.AddComponent<BondUpdater>();
            updater.atomA = bond.atomA;
            updater.atomB = bond.atomB;

            spawnedBonds.Add(bondObj);
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        // Draw bonds in inspector to help track existing ones.
        foreach(var bond in bonds) {
            Vector3 posA = bond.atomA.position;
            Vector3 posB = bond.atomB.position;
            Gizmos.DrawLine(posA, posB);

            // Double bond
            if (bond.bondType == BondType.Double)
            {
                Vector3 dir = (posB - posA).normalized;
                Vector3 offset = Vector3.Cross(dir, Vector3.up) * 0.05f;
                Gizmos.DrawLine(posA + offset, posB + offset);
            }
        }
    }
}
