using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MoleculeManager))]
public class MoleculeManagerEditor : Editor {
    Transform atomA;
    Transform atomB;
    BondType bondType;

    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        MoleculeManager manager = (MoleculeManager)target;

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Add Bond", EditorStyles.boldLabel);

        atomA = (Transform)EditorGUILayout.ObjectField("Atom A", atomA, typeof(Transform), true);
        atomB = (Transform)EditorGUILayout.ObjectField("Atom B", atomB, typeof(Transform), true);
        bondType = (BondType)EditorGUILayout.EnumPopup("Bond Type", bondType);

        if (GUILayout.Button("Add Bond")) {
            if (atomA != null && atomB != null && atomA != atomB) {
                bool exists = manager.bonds.Exists(b =>
                    (b.atomA == atomA && b.atomB == atomB) ||
                    (b.atomA == atomB && b.atomB == atomA)
                );

                if (!exists) {
                    Undo.RecordObject(manager, "Add Bond");
                    manager.bonds.Add(new Bond { atomA = atomA, atomB = atomB, bondType = bondType });
                    EditorUtility.SetDirty(manager);
                } else {
                    Debug.LogWarning("Bond already exists between these atoms!");
                }
            } else {
                Debug.LogWarning("Select two different atoms.");
            }
        }
    }
}
