using System.Collections.Generic;
using DataBase;
namespace Model.Repository;

public class ProfessorFileRepository : IRepository<Professor>
{
    private DB<Professor> database = DB<Professor>.App;

    public List<Professor> All => database.All;

    public void Add(Professor obj){
        List<Professor> list = database.All;
        list.Add(obj);
        database.Save(list);
    }
}