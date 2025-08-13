using UnityEngine;

public class ChemAnimationControl : MonoBehaviour
{
    private Animator anim;
    private float animProgress;

    public Transform chemical_structure;
    private Vector3 scale_change;

    void Start()
    {
        anim = GetComponent<Animator>();
        animProgress = 0f;

        scale_change = new Vector3(0.01f, 0.01f, 0.01f);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A)) animProgress -= 0.0025f;
        if (Input.GetKey(KeyCode.D)) animProgress += 0.0025f;
        if (Input.GetKey(KeyCode.Q)) transform.localScale = transform.localScale - scale_change;
        if (Input.GetKey(KeyCode.E)) transform.localScale = transform.localScale + scale_change;
        animProgress = Mathf.Clamp(animProgress, 0f, 0.99f);
        anim.SetFloat("progress", animProgress);
    }
}
