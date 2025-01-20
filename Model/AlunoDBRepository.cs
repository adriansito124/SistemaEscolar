using System.Collections.Generic;
using DataBase;

namespace Model.Repository;

public class AlunoDBRepository : IRepository<Aluno>
{
    protected DBSqlServer<Aluno> db;
    public AlunoDBRepository()
    {
        db = new DBSqlServer<Aluno>("CA-C-00657\\SQLEXPRESS", "SistemaEscolar");  
    }

    public List<Aluno> All => db.All;

    public void Add(Aluno obj)
    {
        db.Save(obj);
    }
}