using UnityEngine;
using UnityEngine.UI;

public class CameraSetup : MonoBehaviour
{
    [SerializeField] private Material input;
    [SerializeField] private Dropdown select;
    [SerializeField] private RenderTexture[] texture;

    private Camera _cam;

    void Awake()
    {
        _cam = gameObject.GetComponent<Camera>();
        
        SetRenderResolution(1);
        select.SetValueWithoutNotify(1);
    }

    public void SetRenderResolution(int index)
    {
        // Configure Material / Shader
        input.SetTexture("_Input", texture[index]);
        
        // Set Camera output
        _cam.targetTexture = texture[index];
    }
}
