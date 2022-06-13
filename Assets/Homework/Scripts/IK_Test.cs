using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IK_Test : MonoBehaviour
{
    [SerializeField] Transform _handPoint_1;
    [SerializeField] Transform _handPoint_2;
    [SerializeField] Transform _headPoint;
    [SerializeField, Range(0, 1)] float _handWeight;
    [SerializeField, Range(0, 1)] float _lookIKWeight;
    [SerializeField] Vector3 _handOffset;
    [Range(0, 1)] public float eyesWeight;
    [Range(0, 1)] public float headWeight;
    [Range(0, 1)] public float bodyWeight;
    [Range(0, 1)] public float clampWeight;

    [Header("Foot")]
    public float footOffsetY;
    private Vector3 leftFootPos;
    private Vector3 rightFootPos;
    private Quaternion leftFootRot;
    private Quaternion rightFootRot;
    private float leftFootWeight;
    private float rightFootWeight;
    private Transform leftLowerLeg;
    private Transform leftFoot;
    private Transform rightLowerLeg;
    private Transform rightFoot;
    public LayerMask mask;
    private int _rightFootWeightHash;
    private int _leftFootWeightHash;
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        rightFoot = _anim.GetBoneTransform(HumanBodyBones.RightFoot);
        rightLowerLeg = _anim.GetBoneTransform(HumanBodyBones.RightLowerLeg);
        rightFootRot = rightFoot.rotation;

        leftFoot = _anim.GetBoneTransform(HumanBodyBones.LeftFoot);
        leftLowerLeg = _anim.GetBoneTransform(HumanBodyBones.LeftLowerLeg);
        leftFootRot = leftFoot.rotation;

        _rightFootWeightHash = Animator.StringToHash("RightFoot");
        _leftFootWeightHash = Animator.StringToHash("LeftFoot");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (_handPoint_1)
        {
            _anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, _handWeight);
            _anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, _handWeight);
            _anim.SetIKPosition(AvatarIKGoal.LeftHand, _handPoint_1.position + _handOffset);
            _anim.SetIKRotation(AvatarIKGoal.LeftHand, _handPoint_1.rotation);
        }
        if (_handPoint_2)
        {
            _anim.SetIKPositionWeight(AvatarIKGoal.RightHand, _handWeight);
            _anim.SetIKRotationWeight(AvatarIKGoal.RightHand, _handWeight);
            _anim.SetIKPosition(AvatarIKGoal.RightHand, _handPoint_2.position + _handOffset);
            _anim.SetIKRotation(AvatarIKGoal.RightHand, _handPoint_2.rotation);
        }

        if (_headPoint)
        {
            _anim.SetLookAtWeight(_lookIKWeight, eyesWeight, headWeight, bodyWeight, clampWeight);
            _anim.SetLookAtPosition(_headPoint.position);
        }

        /*rightFootWeight =*/ _anim.GetFloat(_rightFootWeightHash);
        if (Physics.Raycast(rightLowerLeg.position, Vector3.down, out var hitR, 2f, mask))
        {
            rightFootPos = Vector3.Lerp(rightFootPos, hitR.point + Vector3.up * footOffsetY, Time.deltaTime * 10f);
            rightFootRot = Quaternion.FromToRotation(transform.up, hitR.normal) * transform.rotation;
        }

        _anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, rightFootWeight);
        _anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, rightFootWeight);
        _anim.SetIKPosition(AvatarIKGoal.RightFoot, rightFootPos);
        _anim.SetIKRotation(AvatarIKGoal.RightFoot, rightFootRot);

        /*leftFootWeight =*/ _anim.GetFloat(_leftFootWeightHash);
        if (Physics.Raycast(leftLowerLeg.position, Vector3.down, out var hitL, 2f, mask))
        {
            leftFootPos = Vector3.Lerp(leftFootPos, hitL.point + Vector3.up * footOffsetY, Time.deltaTime * 10f);
            leftFootRot = Quaternion.FromToRotation(transform.up, hitL.normal) * transform.rotation;            
        }

        _anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, leftFootWeight);
        _anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, leftFootWeight);
        _anim.SetIKPosition(AvatarIKGoal.LeftFoot, leftFootPos);
        _anim.SetIKRotation(AvatarIKGoal.LeftFoot, leftFootRot);
    }
}
