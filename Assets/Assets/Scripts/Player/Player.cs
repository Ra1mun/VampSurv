using System;

public class Player : Entity
{
    private void Awake()
    {
        _type = EntityType.Player;
    }
}