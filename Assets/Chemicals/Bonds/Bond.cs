using UnityEngine;

[System.Serializable]
public class Bond {
    public Transform atomA;
    public Transform atomB;
    public BondType bondType;
}

public enum BondType
{
    Single,
    Double
}
