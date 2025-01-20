using System.Data;
using DataBase;

namespace Model;

public class Aluno : DataBaseObject
{

    public string Nome { get; set; }

    public int Idade { get; set; }
    protected override void LoadFrom(string[] data)
    {
        this.Nome = data[0];
        this.Idade = int.Parse(data[1]);
    }

    protected override void LoadFromSqlRow(DataRow data)
    {
        this.Nome = data[0].ToString();
        this.Idade = int.Parse(data[1].ToString());
    }

    protected override string[] SaveTo() => new string[]
    {
        this.Nome,
        this.Idade.ToString()    
    };

    protected override string SaveToSql()
        => $"INSERT INTO [Alunos] VALUES ('{this.Nome}', {this.Idade})";
    
}