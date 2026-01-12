namespace TaskList.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; private set; } 

        public string Email { get; private set; }  

        public string Senha { get; set; }  

        protected Usuario() { }

        public Usuario(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }


    }
}
