namespace DataBase;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Data;
using System.IO;
using Exceptions;

public class DB<T>
    where T : DataBaseObject, new()
{
    protected string basePath;

    protected DB(string basePath) 
        => this.basePath = basePath;

    public string DBPath {
        get{
            var filename = typeof(T).Name;
            var path = this.basePath + filename + ".csv";
            return path;
        }
    }

    protected List<string> openFile(){
        List<string> lines = new();
        StreamReader reader = null;
        var path = this.DBPath;

        if (!File.Exists(path))
        {
            File.Create(path).Close();
        }

        try{
            reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                lines.Add(reader.ReadLine());
            }
        }
        catch{
            lines=null;
        }
        finally{
            reader?.Close();
        }

        return lines;
    }

    protected bool saveFile(List<string> lines){
        StreamWriter writter = null;
        bool succes = true;
        var path = this.DBPath;

        if (!File.Exists(path))
        {
            File.Create(path).Close(); 
        }

        try
        {
            writter = new StreamWriter(path);
            for (int i = 0; i < lines.Count; i++)
            {
                var line = lines[i];
                writter.WriteLine(line);
            }
        }
        catch
        {
            succes = false;
        }
        finally{
            writter.Close();
        }

        return succes;
    }

    public List<T> All
    {
        get
        {
            var lines = openFile();
            if (lines is null)
            {
                throw new DataCannotBeOpenedException(this.DBPath);
            }
            var all = new List<T>();

            try
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    var line = lines[i];
                    var obj = new T();
                    var data = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    obj.LoadFrom(data);
                    all.Add(obj);
                }
            }
            catch
            {
                throw new ConvertObjectException();
            }

            return all;
        }
    }

    public void Save (List<T> all)
    {
        List<string> lines = new();
        for (int i = 0; i< all.Count; i++)
        {
            var data = all[i].SaveTo();
            string line = string.Empty;
            for (int j = 0; j < data.Length; j++)
            {
                line += data[j] + ",";
            }
            lines.Add(line);
        }

        if(saveFile(lines))
        {
            return;
        }

        throw new DataCannotBeOpenedException(this.DBPath);
    }

    protected static DB<T> temp = null;

    public static DB<T> Temp
    {
        get
        {
            if(temp == null){
                temp = new DB<T>(Path.GetTempPath());
            }
            return temp;
        }
    }

    protected static DB<T> app = null;
    public static DB<T> App
    {
        get
        {
            if(app == null){
                app = new DB<T>("");
            }
            return app;
        }
    }

    protected static DB<T> custom = null;
    public static DB<T> Custom
    {
        get
        {
            if (custom == null){
                throw new CustomNotDefinedException();
            }
            return custom;
        }
    }

    public static void SetCustom(string path) 
        => custom = new DB<T>(path);
}