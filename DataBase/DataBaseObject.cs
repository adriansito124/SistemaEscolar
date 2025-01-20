using System.Data;

namespace DataBase;

public abstract class DataBaseObject
{
    internal protected abstract void LoadFrom(string[] data);
    internal protected abstract string[] SaveTo();

    internal protected abstract void LoadFromSqlRow(DataRow data);
    internal protected abstract string SaveToSql();
}