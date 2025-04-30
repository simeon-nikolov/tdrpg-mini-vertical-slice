using UnityEngine;

public class BoneAdjuster : MonoBehaviour
{
    public Transform upperArmBone;
    public Transform handBone;
    public Animator animator;

    [Header("Offsets")]
    public Vector3 walkingUpperArmOffset = new Vector3(0, 305, 18);
    public Vector3 walkingHandOffset = new Vector3(275, 90, 270);
    public Vector3 idleUpperArmOffset = new Vector3(0, 0, 0);
    public Vector3 idleHandOffset = new Vector3(0, 0, 0);

    [Header("Blend Settings")]
    public float blendSpeed = 5f;

    private Vector3 currentUpperArmOffset;
    private Vector3 currentHandOffset;

    void Start()
    {
        currentUpperArmOffset = idleUpperArmOffset;
        currentHandOffset = idleHandOffset;
    }

    void LateUpdate()
    {
        if (upperArmBone == null || handBone == null || animator == null)
            return;

        // 1. Save the current animation pose
        Vector3 baseUpperArmRotation = upperArmBone.localEulerAngles;
        Vector3 baseHandRotation = handBone.localEulerAngles;

        // 2. Choose the target offsets
        Vector3 targetUpperArmOffset;
        Vector3 targetHandOffset;

        if (animator.GetBool(AnimatorConstants.WALKING_PARAM))
        {
            targetUpperArmOffset = walkingUpperArmOffset;
            targetHandOffset = walkingHandOffset;
        }
        else
        {
            targetUpperArmOffset = idleUpperArmOffset;
            targetHandOffset = idleHandOffset;
        }

        // 3. Blend the current offset towards the target offset
        currentUpperArmOffset = Vector3.Lerp(currentUpperArmOffset, targetUpperArmOffset, Time.deltaTime * blendSpeed);
        currentHandOffset = Vector3.Lerp(currentHandOffset, targetHandOffset, Time.deltaTime * blendSpeed);

        // 4. Apply the offset
        upperArmBone.localEulerAngles = baseUpperArmRotation + currentUpperArmOffset;
        handBone.localEulerAngles = baseUpperArmRotation + currentUpperArmOffset;
    }
}
