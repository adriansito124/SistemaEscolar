namespace Model;

using DataBase;

public class TurmaFileRepository : IRepository<Turma>
{
    private DB<Turma> database = DB<Turma>.App;

    public List<Turma> All => database.All;

    public void Add(Turma obj){
        List<Turma> list = database.All;
        list.Add(obj);
        database.Save(list);
    }

}