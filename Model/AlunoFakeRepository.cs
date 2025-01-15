using System.Collections.Generic;

namespace Model;

public class AlunoFakeRepository : IRepository<Aluno>
{
    List<Aluno> alunos = [];

    public AlunoFakeRepository()
    {
        alunos.Add(new (){
            Nome = "Adrian",
            Idade = 18
        });

        alunos.Add(new (){
            Nome = "Jubileu",
            Idade = 24
        });
    }
    public List<Aluno> All => alunos;

    public void Add(Aluno obj) => this.alunos.Add(obj);
}