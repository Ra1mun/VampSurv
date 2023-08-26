using System;
using System.Collections.Generic;

public class Attributes
{
    private Dictionary<AttributeType, int> _attributeLevels = new Dictionary<AttributeType, int>()
    {

        [AttributeType.Atheism] = 0,
        [AttributeType.Christianity] = 0,
        [AttributeType.Paganism] = 0,
    };

    public Action<AttributeType, int> OnLevelChanged;
    
    public void AttributeLevelUp(AttributeType type, int exp)
    {
        _attributeLevels[type] += exp;
    }
}
