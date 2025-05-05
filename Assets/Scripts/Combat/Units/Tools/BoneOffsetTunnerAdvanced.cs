using UnityEngine;

[ExecuteAlways]
public class BoneOffsetTunerAdvanced : MonoBehaviour
{
    public bool applyOffsets = true;
    public Transform upperArmBone;
    public Transform handBone;

    [Header("Rotation Offsets (Degrees)")]
    public Vector3 upperArmRotationOffset;
    public Vector3 handRotationOffset;

    public Vector3 initialUpperArmRotation;
    public Vector3 initialHandRotation;
    private bool initialized = false;

    private void OnEnable()
    {
        SaveInitialRotations();
    }

    public void SaveInitialRotations()
    {
        if (upperArmBone != null)
            initialUpperArmRotation = upperArmBone.localEulerAngles;
        if (handBone != null)
            initialHandRotation = handBone.localEulerAngles;

        initialized = true;
    }

    private void LateUpdate()
    {
        if (!initialized)
        {
            SaveInitialRotations();
        }

        if (applyOffsets)
        {
            ApplyOffsets();
        }
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (!Application.isPlaying)
        {
            //SaveInitialRotations();
            ApplyOffsets();
        }
    }
#endif

    private void ApplyOffsets()
    {
        if (upperArmBone != null)
        {
            upperArmBone.localEulerAngles = initialUpperArmRotation + upperArmRotationOffset;
        }

        if (handBone != null)
        {
            handBone.localEulerAngles = initialHandRotation + handRotationOffset;
        }
    }
}
