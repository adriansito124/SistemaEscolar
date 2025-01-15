using static System.Console;
using Model;
using Model.Repository;
using System.Linq;
using System.Collections.Generic;

IRepository<Aluno> alunoRepo = null;
IRepository<Professor> profRepo = null;
IRepository<Disciplina> dRepo = null;
IRepository<Turma> turmaRepo = null;

alunoRepo = new AlunoFakeRepository();
profRepo = new ProfessorFakeRepository();
dRepo = new DisciplinaFakeRepository();
turmaRepo = new TurmaFakeRepository();

while (true)
{
    try
    {
        Clear();
        WriteLine("\n1 - Cadastrar Professor\n2 - Cadastrar Aluno\n3 - Ver Professores\n4 - Ver Alunos\n5 - Sair\n6 - Cadastrar Disciplina\n7 - Ver Disciplinas\n8 - Cadastrar Turma\n9 - Ver Turma");

        int option = int.Parse(ReadLine());

        switch (option)
        {
            case 1:
                Clear();
                Professor professor = new();
                WriteLine("Insira o nome do professor: ");
                professor.Nome = ReadLine();
                WriteLine("Insira a formacao do professor: ");
                professor.Formacao = ReadLine();
                profRepo.Add(professor);
                break;
            case 2:
                Clear();
                Aluno aluno = new();
                WriteLine("Insira o nome do aluno: ");
                aluno.Nome = ReadLine();
                WriteLine("Insira a idade do aluno: ");
                aluno.Idade = int.Parse(ReadLine());
                alunoRepo.Add(aluno);
                break;
            case 3:
                var profs = profRepo.All;
                foreach (var prof in profs)
                {
                    WriteLine($"{prof.Formacao} - {prof.Nome}");
                }
                break;
            case 4:
                var alunos = alunoRepo.All;
                foreach (var a in alunos)
                {
                    WriteLine($"{a.Nome} - {a.Idade}");
                }
                break;
            case 5:
                return;
            case 6:
                Clear();
                var profes = profRepo.All;
                Disciplina disciplina = new();
                WriteLine("Insira o nome da disciplina: ");
                disciplina.Nome = ReadLine();
                WriteLine("Insira o professor: ");
                string nomeprof = ReadLine();
                foreach (var item in profes)
                {
                    if (item.Nome == nomeprof)
                    {
                        disciplina.professor = item;
                    }
                }
                if (disciplina.professor == null)
                {
                    WriteLine("professor não encontrado!");
                }
                else{
                    dRepo.Add(disciplina);
                }
                break;
            case 7:
                var dis = dRepo.All;
                foreach (var d in dis)
                {
                    WriteLine($"{d.Nome} - {d.professor.Nome}");
                }
                break;
            case 8:
            Clear();
                var alus = alunoRepo.All;
                var disciplinas = dRepo.All;
                Turma turma = new();
                WriteLine("Insira o nome da turma: ");
                turma.Nome = ReadLine();
                WriteLine("Insira a disciplina: ");
                string nomedis = ReadLine();
                foreach (var item in disciplinas)
                {
                    if (item.Nome == nomedis)
                    {
                        turma.disciplinaID = turma.disciplinaID + $"{item.Nome},";
                        turma.professorID = turma.disciplinaID + $"{item.professor.Nome}";
                    }
                }
                WriteLine("Insira o aluno: ");
                string nomeal = ReadLine();
                foreach (var item in alus)
                {
                    if (item.Nome == nomeal)
                    {
                        turma.alunosID = turma.alunosID + $"{item.Nome},";
                    }
                }
                break;
            case 9:
                var turmas = turmaRepo.All;
                foreach (var t in turmas)
                {
                    WriteLine($"{t.Nome} - {t.IDProfessor[0]} - {t.IDDisciplina[0]} - {t.IDAluno[0]}");
                }
                break;
            default:
                break;
        }
    }
    catch
    {
        WriteLine("Erro na aplicacao :(");
    }

    WriteLine("Pressione qualquer tecla para continuar;");
    ReadKey(true);
}