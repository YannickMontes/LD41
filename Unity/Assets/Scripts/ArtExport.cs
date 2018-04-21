using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ArtExport : MonoBehaviour {


    [SerializeField]
    private Camera cameraTop;
    
    private RenderTexture renderTexture;

    // Use this for initialization
    void Start()
    {
             
    }


    void Awake()
    {
        renderTexture = cameraTop.targetTexture;
        exportArtToPNG();
        Debug.Log("c'est fini l'export tamere");
    }



    public void exportArtToPNG()
    {
        int width = renderTexture.width;
        int height = renderTexture.height;

        //virer les mobs et le player 

        cameraTop.Render();

        RenderTexture.active = renderTexture;

        Texture2D exportPNGTexture = new Texture2D(width, height, TextureFormat.RGBA32, false);

        exportPNGTexture.ReadPixels(new Rect(0, 0, width, height), 0 , 0);

        exportPNGTexture.Apply();

        byte[] bytes = exportPNGTexture.EncodeToJPG();

        Object.Destroy(exportPNGTexture);
        
        File.WriteAllBytes(Application.dataPath + "/../SavedScreen.png", bytes);

    }
}
