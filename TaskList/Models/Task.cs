namespace TaskList.Models
{
    public class TaskItem
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }

        public bool TarefaConcluida { get; private set; }


        protected TaskItem() { }

        public TaskItem(string titulo, string descricao)
        {
            Titulo = titulo;
            Descricao = descricao;
            TarefaConcluida = false;
        }

        public void Atualizar(string titulo, string descricao)
        {
            Titulo = titulo;
            Descricao = descricao;
        }

        public void MarcarComoConcluida()
        {
            TarefaConcluida = true;
        }


    }
}
