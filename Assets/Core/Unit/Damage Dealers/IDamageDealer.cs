namespace Core.Unit.Damage_Dealers
{
    public interface IDamageDealer
    {
        void Rest();
        void TryDamage(Unit target, int damage);
    }
}