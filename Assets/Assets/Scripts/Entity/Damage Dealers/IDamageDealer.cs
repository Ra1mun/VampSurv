public interface IDamageDealer
{
    void Rest();
    void TryDamage(EntityHealth target, int damage);
}