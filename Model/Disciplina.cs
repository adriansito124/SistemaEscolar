using System.Data;
using DataBase;

namespace Model;

public class Disciplina : DataBaseObject
{
    public string Nome { get; set; }
    public Professor professor = new Professor();   
    protected override void LoadFrom(string[] data)
    {
        this.Nome = data[0];
        this.professor.Nome = data[1];
    }

    protected override string[] SaveTo() => 
    [
        this.Nome,
        this.professor.Nome,
    ];

    protected override void LoadFromSqlRow(DataRow data)
    {
        throw new NotImplementedException();
    }

    protected override string SaveToSql()
    {
        throw new NotImplementedException();
    }
}