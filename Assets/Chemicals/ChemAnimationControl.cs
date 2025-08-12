using UnityEngine;

public class ChemAnimationControl : MonoBehaviour
{
    private Animator anim;
    private float animProgress;

    void Start()
    {
        anim = GetComponent<Animator>();
        animProgress = 0f;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A)) animProgress -= 0.0025f;
        if (Input.GetKey(KeyCode.D)) animProgress += 0.0025f;
        animProgress = Mathf.Clamp(animProgress, 0f, 0.99f);
        anim.SetFloat("progress", animProgress);
    }
}
