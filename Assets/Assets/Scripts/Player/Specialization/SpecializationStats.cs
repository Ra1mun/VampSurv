using System;

public class SpecializationStats : StatsDecorator
{
    private readonly Specialization _speciazliation;

    public SpecializationStats(IStatsProvider wrappedEntity, Specialization speciazliation) : base(wrappedEntity)
    {
        _speciazliation = speciazliation;
    }

    protected override PlayerStats GetStatsInternal()
    {
        return _wrappedEntity.GetStats() + GetSpecializationStats(_speciazliation);
    }

    private PlayerStats GetSpecializationStats(Specialization spec)
    {
        switch (spec)
        {
            case Specialization.Warrior:
                return new PlayerStats
                {
                    MaxHealth = 50,
                    AttackDistance = 5,
                    AttackSpeed = 10,
                    Damage = 20,
                    MoveSpeed = 25
                };
            case Specialization.Ancher:
                return new PlayerStats
                {
                    MaxHealth = 40,
                    AttackDistance = 5,
                    AttackSpeed = 15,
                    Damage = 10,
                    MoveSpeed = 35
                };
            default:
                throw new NotImplementedException($"Spec {_speciazliation} is not founded.");
        }
    }
}