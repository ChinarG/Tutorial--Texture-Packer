using UnityEngine;
using System.Collections.Generic;


/// <summary>
/// 静态函数，无需挂载
/// 主函数：LoadSprite()
/// </summary>
public class ChinarAtlas
{
    private static readonly Dictionary<string, Object[]> _atlasDic = new Dictionary<string, Object[]>(); //图集字典


    /// <summary>
    /// 加载对应图集中，对应名称的精灵图片
    /// </summary>
    /// <param name="atlasPath">图集路径</param>
    /// <param name="spriteName">精灵名称</param>
    /// <param name="isResources">默认内部 Resources 加载，false 时，通过 AssetBundle 方式加载</param>
    /// <returns>Sprite</returns>
    public static Sprite LoadSprite(string atlasPath, string spriteName, bool isResources = true)
    {
        Sprite sprite                                = null;                                                               //字典中包含 目标图集
        if (_atlasDic.ContainsKey(atlasPath)) sprite = SpriteFormAtlas(_atlasDic[atlasPath], spriteName);                  //得到该图集中对应名称的 Sprite
        if (sprite != null) return sprite;                                                                                 //返回找到的 Sprite
        Object[] atlas = isResources ? Resources.LoadAll(atlasPath) : AssetBundle.LoadFromFile(atlasPath).LoadAllAssets(); //选择内外部加载方式
        _atlasDic.Add(atlasPath, atlas);                                                                                   //到字典中
        sprite = SpriteFormAtlas(atlas, spriteName);                                                                       //找到 Sprite
        return sprite;                                                                                                     //返回找到的 Sprite
    }


    /// <summary>
    /// 删除图集缓存
    /// </summary>
    /// <param name="atlasPath">图集路径</param>
    public static void DeleteAtlas(string atlasPath)
    {
        if (_atlasDic.ContainsKey(atlasPath)) _atlasDic.Remove(atlasPath);
    }


    /// <summary>
    /// 遍历图集并找出 Sprite
    /// </summary>
    /// <param name="atlas">Object[]</param>
    /// <param name="spriteName">精灵名称</param>
    /// <returns>Sprite</returns>
    private static Sprite SpriteFormAtlas(Object[] atlas, string spriteName)
    {
        foreach (var obj in atlas)
        {
            if (obj != null && obj is Sprite && obj.name == spriteName) return (Sprite) obj;
        }

        Debug.LogWarning("图集中未查找到名为：<" + spriteName + ">的精灵");
        return null;
    }
}