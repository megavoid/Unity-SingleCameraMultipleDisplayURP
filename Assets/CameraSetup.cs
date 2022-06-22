using UnityEngine;

public class CameraSetup : MonoBehaviour
{
    public Material input;
    public RenderTexture textureHD;
    public RenderTexture texture4K;
    void Awake()
    {
        RenderTexture renderTexture = textureHD;
        Camera cam = gameObject.GetComponent<Camera>();
        
        
        input.SetTexture("_Input", renderTexture);
        cam.targetTexture = renderTexture;
        
    }
}
