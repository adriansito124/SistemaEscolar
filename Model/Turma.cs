using DataBase;

namespace Model;

public class Turma : DataBaseObject
{  
    public string Nome { get; set; }

    public List<string> IDProfessor = new List<string>(){};

    public string professorID { get; set; }

    public List<string> IDDisciplina = new List<string>(){};

    public string disciplinaID { get; set; }

    public List<string> IDAluno = new List<string>(){};

    public string alunosID { get; set; }



    protected override void LoadFrom(string[] data)
    {
        this.Nome = data[0];
        this.IDProfessor = data[1].Split(',').ToList();
        this.IDDisciplina = data[2].Split(',').ToList();
        this.IDAluno = data[3].Split(',').ToList();

    }

    protected override string[] SaveTo() => [
        this.Nome,
        this.professorID,
        this.disciplinaID,
        this.alunosID
    ];
}