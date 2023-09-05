public class AttributeStatsDecorator : StatsDecorator
{
    private readonly AttributeType _type;
    
    public AttributeStatsDecorator(IStatsProvider wrappedEntity, AttributeType type) : base(wrappedEntity)
    {
        _type = type;
    }

    protected override Stats GetStatsInternal()
    {
        var stat = new Stats();
        switch (_type)
        {
            case AttributeType.Christianity:
                stat += new Stats()
                {
                    MaxHealth = 10,
                };
                break;
            case AttributeType.Atheism:
                stat += new Stats()
                {
                    MaxHealth = 10,
                };
                break;
            case AttributeType.Paganism:
                stat += new Stats()
                {
                    MaxHealth = 10,
                };
                break;
        }

        return _wrappedEntity.GetStats() + stat;
    }
}
