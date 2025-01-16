using System.Collections.Generic;
using DataBase;

namespace Model;

public class AlunoFileRepository : IRepository<Aluno>
{
    private DB<Aluno> database = DB<Aluno>.App;
    public List<Aluno> All => database.All;

    public void Add(Aluno obj)
    {
        List<Aluno> list = database.All;
        list.Add(obj);
        database.Save(list);
    }
} 
