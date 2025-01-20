namespace DataBase;

public abstract class DataBase<T>
{
    private string basePath;

    public string DBPath;

    public List<T> All;

    protected static DataBase<T> temp = null;
    protected static DataBase<T> app = null;
    protected static DataBase<T> custom = null;

    protected abstract List<string> openFile();

    protected abstract bool saveFile(List<string> lines);

    public abstract void Save (List<T> all);
}