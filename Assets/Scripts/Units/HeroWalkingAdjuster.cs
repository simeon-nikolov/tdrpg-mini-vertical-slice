using UnityEngine;

public class HeroWalkingAdjuster : MonoBehaviour
{
    public Transform upperArmBone;
    public Transform lowerArmBone;
    public Transform handBone;
    private Animator animator;

    [Header("Offsets")]
    public Vector3 upperArmOffset = new Vector3(0, -55, 18);
    public Vector3 lowerArmOffset = new Vector3(0, 0, 45);
    public Vector3 handOffset = new Vector3(-90, 0, 0);

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void LateUpdate()
    {
        if (upperArmBone == null || handBone == null || animator == null)
            return;

        if (animator.GetBool(AnimatorConstants.WALKING_PARAM))
        {
            upperArmBone.localEulerAngles = upperArmOffset;
            lowerArmBone.localEulerAngles = lowerArmOffset;
            handBone.localEulerAngles = handOffset;
        }
    }
}
