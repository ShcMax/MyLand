using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Focus : MonoBehaviour
{
    private DepthOfField _depthOfField;
    public float _focus;
    public float _focusMin = 0.1f;
    private PostProcessVolume _postProcessVolume;
    public LayerMask _mask;
    public Transform _player;
    // Start is called before the first frame update
    void Start()
    {
        _postProcessVolume = GetComponent<PostProcessVolume>();
        _postProcessVolume.profile.TryGetSettings(out _depthOfField);

        _depthOfField.enabled.value = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(_player.position, Vector3.forward, out var hitR, 3f, _mask))
        {
            _depthOfField.focusDistance.value = _focus;            
        }
        else
        {
            _depthOfField.focusDistance.value = _focusMin;
        }
    }
}
