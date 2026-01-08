namespace TaskList.Models
{
    public class TaskItem
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
      

        public TaskItem(string titulo, string descricao)
        {
            Titulo = titulo;
            Descricao = descricao;
        }
    }
}
