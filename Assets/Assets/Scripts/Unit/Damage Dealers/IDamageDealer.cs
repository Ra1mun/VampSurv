public interface IDamageDealer
{
    void Rest();
    void TryDamage(Unit target, int damage);
}