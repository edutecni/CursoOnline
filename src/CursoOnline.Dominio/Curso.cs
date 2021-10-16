using System;

namespace CursoOnline.Dominio.Cursos
{
    // Modelo de Objetos podem ser Modelo Rico e Modelo Anêmico.
    // Modelos Anêmicos só possuem propriedades que normalmente refletem o  Banco de Dados.
    // Modelos Ricos além das Propriedades possuem também Comportamentos (Métodos).
    // Lógo Mdelo Rico  é quando o domínio tem comportamentos para tratar, validar e agir com seus dados,
    // sem a ajuda de nenhuma outra classe.
    public class Curso
    {
        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public double ValorCurso { get; private set; }

        //public Curso() { }

        public Curso(string nome, double cargaHoraria, PublicoAlvo publicoAlvo, double valorCurso)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException();

            this.Nome = nome;
            this.CargaHoraria = cargaHoraria;
            this.PublicoAlvo = publicoAlvo;
            this.ValorCurso = valorCurso;
        }
    }
    public enum PublicoAlvo
    {
        Estudante,
        Universitário,
        Empregado,
        Empreendedor
    }
}