using System.Collections.Generic;
using Assets.Scripts.UI.ItemSelection;
using Unity.VisualScripting;

public class AssetItemGenerator
{
    private readonly AssetItemSelectionConfig _config;
    
    public AssetItemGenerator(AssetItemSelectionConfig config)
    {
        _config = config;
    }

    public List<AssetItem> GenerateAssetItem(int count)
    {
        var result = new List<AssetItem>();
        for (int i = 0; i < count; i++)
        {
            result.Add(_config.GetRandomItem());
        }

        return result;
    }
}
