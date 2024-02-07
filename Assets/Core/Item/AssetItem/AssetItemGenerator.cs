using System.Collections.Generic;

namespace Core.Item.AssetItem
{
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

            while (result.Count != count)
            {
                var randomItem = _config.GetRandomItem();

                if (!result.Contains(randomItem)) result.Add(randomItem);
            }

            return result;
        }
    }
}