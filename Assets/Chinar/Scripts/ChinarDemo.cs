using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 动态读取数据、添加/改变UI元素
/// </summary>
public class ChinarDemo : MonoBehaviour
{
    private AssetBundle ab; //AB包对象


    public Image UiResourcesImage
    {
        get { return GameObject.Find("Resources Image").GetComponent<Image>(); }
    }

    public Image UiAssetBundleImage
    {
        get { return GameObject.Find("AssetBundle Image").GetComponent<Image>(); }
    }


    void Start()
    {
        ResourcesLoadMethod();
        AssetBundleLoadMethod();
    }


    /// <summary>
    /// 第一种：Resources加载 —— 内部 
    /// </summary>
    private void ResourcesLoadMethod()
    {
        UiResourcesImage.sprite = ChinarAtlas.LoadSprite("Texture/Atlas/Chinar", "Chinar1");
    }


    /// <summary>
    /// 第二种：AssetBundle加载 —— 外部 
    /// </summary>
    private void AssetBundleLoadMethod()
    {
        UiAssetBundleImage.sprite = ChinarAtlas.LoadSprite(Application.streamingAssetsPath + "/ChinarAssetBundles/atlas/chinar.unity3d", "Chinar2", false);
    }
}