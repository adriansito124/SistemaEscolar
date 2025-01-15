namespace DataBase;

public abstract class DataBaseObject
{
    internal protected abstract void LoadFrom(string[] data);
    internal protected abstract string[] SaveTo();
}