using DataBase;

namespace Model;

public class Professor : DataBaseObject
{
    public string Nome { get; set; }
    public string Formacao { get; set; }
    protected override void LoadFrom(string[] data)
    {
        this.Nome = data[0];
        this.Formacao = data[1];
    }

    protected override string[] SaveTo() => [
        this.Nome,
        this.Formacao,
    ];
}