using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ModuleType { statsModule, offensiveModule} //����� ����� ������� ��������

[CreateAssetMenu(fileName ="New Module", menuName ="Tower Modules/basicModule", order =1)]

public class ModuleConfig : ScriptableObject
{
    [SerializeField] public ModuleType type;
    [SerializeField] public string _name;
    [SerializeField] public string _description;
    //�������� ����� ���� ����� �������� ���� icon,sprite, etc.
    [SerializeField] protected float _damage;
    [SerializeField] protected float _attackSpeed;
    [SerializeField] protected IActiveModule _modulePref;

    //stats to increase
    [SerializeField] private int _maxHealth;

    public int MaxHealth { get => _maxHealth;}

    private void Awake()
    {
        //UseModuleLogic();
            
    }
    
    public virtual void Use()
    {
        //���� �������� �����, ���� ������� "������" ������� ����� ���������
    }

}
