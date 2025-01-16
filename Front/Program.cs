using static System.Console;
using Model;
using Model.Repository;
using System.Linq;
using System.Collections.Generic;

IRepository<Aluno> alunoRepo = null;
IRepository<Professor> profRepo = null;
IRepository<Disciplina> dRepo = null;
IRepository<Turma> turmaRepo = null;

alunoRepo = new AlunoFileRepository();
profRepo = new ProfessorFileRepository();
dRepo = new DisciplinaFileRepository();
turmaRepo = new TurmaFileRepository();

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
                else
                {
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
                var turmaz = turmaRepo.All;
                Turma turma = new();
                WriteLine("Insira o nome da turma: ");
                turma.Nome = ReadLine();
                WriteLine("Insira quantidade de disciplinas: ");
                int qtdDis = int.Parse(ReadLine());
                for (int i = 0; i < qtdDis; i++)
                {
                    WriteLine("Insira a disciplina: ");
                    string nomedis = ReadLine();
                    foreach (var item in disciplinas)
                    {
                        if (item.Nome == nomedis)
                        {
                            turma.IDDisciplina.Add(item.Nome);
                            turma.IDProfessor.Add(item.professor.Nome);
                        }
                    }
                }
                WriteLine("Insira quantidade de alunos: ");
                int qtdAlunos = int.Parse(ReadLine());
                for (int i = 0; i < qtdAlunos; i++)
                {
                    WriteLine("Insira o aluno: ");
                    string nomeal = ReadLine();
                    foreach (var item in alus)
                    {
                        if (item.Nome == nomeal)
                        {
                            turma.IDAluno.Add(item.Nome);
                        }
                    }
                }
                turmaRepo.Add(turma);
                break;
            case 9:
                var turmas = turmaRepo.All;
                int ind = 0;
                foreach (var t in turmas)
                {
                    WriteLine($"Turma: {t.Nome} ");
                    WriteLine($"Professor(es): ");
                    for (int i = 0; i < turmas[ind].IDDisciplina.Count; i++)
                    {
                        WriteLine($"-> {t.IDProfessor[i]} ");
                    }
                    WriteLine($"Disciplina(s): ");
                    for (int i = 0; i < turmas[ind].IDDisciplina.Count; i++)
                    {
                        WriteLine($"-> {t.IDDisciplina[i]} ");
                    }
                    WriteLine($"Aluno(s): ");
                    for (int i = 0; i < turmas[ind].IDAluno.Count; i++)
                    {
                         WriteLine($"-> {t.IDAluno[i]} ");
                    }
                    ind = ind+1;
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