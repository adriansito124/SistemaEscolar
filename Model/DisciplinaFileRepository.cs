using DataBase;

namespace Model;

public class DisciplinaFileRepository : IRepository<Disciplina>
{ 
    private DB<Disciplina> database = DB<Disciplina>.App;

    public List<Disciplina> All => database.All;

    public void Add(Disciplina obj){
        List<Disciplina> list = database.All;
        list.Add(obj);
        database.Save(list);
    }
}