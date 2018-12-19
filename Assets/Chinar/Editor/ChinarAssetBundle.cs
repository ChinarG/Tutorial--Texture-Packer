using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;


/// <summary>
/// 打包脚本 —— 放在 Editor 文件夹下(规范)
/// </summary>
public class ChinarAssetBundle
{
    private static readonly string targetPath = Application.streamingAssetsPath + "/ChinarAssetBundles/"; //目标位置


    [MenuItem("Chinar工具/打包AssetsBundle资源")]
    //菜单栏添加按钮
    static void BuildAllAssetsBundles()
    {
        if (!Directory.Exists(Application.streamingAssetsPath + "/ChinarAssetBundles")) Directory.CreateDirectory(targetPath);     //文件夹不存在，则创建
        BuildPipeline.BuildAssetBundles(targetPath, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows); //创建AssetBundle
        AssetDatabase.Refresh();
    }
}