using UnityEngine;

[ExecuteAlways]
public class BoneOffsetTuner : MonoBehaviour
{
    public Transform upperArmBone;
    public Transform handBone;

    [Header("Rotation Offsets (Degrees)")]
    public Vector3 upperArmRotationOffset;
    public Vector3 handRotationOffset;

    private void LateUpdate()
    {
        if (upperArmBone == null || handBone == null)
            return;

        // Get the base animation pose
        Vector3 baseUpperArmRotation = upperArmBone.localEulerAngles;
        Vector3 baseHandRotation = handBone.localEulerAngles;

        // Apply offsets
        upperArmBone.localEulerAngles = baseUpperArmRotation + upperArmRotationOffset;
        handBone.localEulerAngles = baseHandRotation + handRotationOffset;
    }
}
