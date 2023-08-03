public interface IDamageDealer
{
    void Rest();
    void TryDamage(Entity target, int damage);
}