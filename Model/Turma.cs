using System.Data;
using DataBase;

namespace Model;

public class Turma : DataBaseObject
{
    public string Nome { get; set; }

    public List<string> IDProfessor = new List<string>() { };

    public List<string> IDDisciplina = new List<string>() { };

    public List<string> IDAluno = new List<string>() { };


    protected override void LoadFrom(string[] data)
    {
        this.Nome = data[0];
        this.IDProfessor = data[1].Split(',').ToList();
        this.IDDisciplina = data[2].Split(',').ToList();
        this.IDAluno = data[3].Split(',').ToList();

    }

    protected override string[] SaveTo() => new string[]
    {
        this.Nome,
        string.Join(",", this.IDProfessor),
        string.Join(",", this.IDDisciplina),
        string.Join(",", this.IDAluno)
    };

    protected override void LoadFromSqlRow(DataRow data)
    {
        throw new NotImplementedException();
    }

    protected override string SaveToSql()
    {
        throw new NotImplementedException();
    }
}