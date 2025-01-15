using DataBase;

namespace Model;

public class Disciplina : DataBaseObject
{
    public string Nome { get; set; }
    public Professor professor;   
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
}