namespace CursoOnline.Dominio.Cursos
{
    public class Curso
    {
        
        public string Nome { get; set; }
        public double CargaHoraria { get; private set; }
        public string PublicoAlvo { get; private set; }
        public double ValorCurso { get; private set; }

        //public Curso() { }

        public Curso(string nome, double cargaHoraria, string publicoAlvo, double valorCurso)
        {
            this.Nome = nome;
            this.CargaHoraria = cargaHoraria;
            this.PublicoAlvo = publicoAlvo;
            this.ValorCurso = valorCurso;
        }
    }
}