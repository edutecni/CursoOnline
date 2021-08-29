using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CursoOnline.Dominio.Cursos;

namespace CursoOnline.DominioTest.Cursos
{
    public class CursoTest
    {
        // "Eu, enquanto administrador quero criar e editar curso parq que sejam abertas instrções para o mesmo."

        // Critério de aceite

        // - Criar um curso com, nome carga hotária, publico alvo e valor do curso.
        // - As opções para público alvo são: Estudante, Universitário, Empregado e Empregador.
        // - Todos os campos do curso são obrigatório.


        [Fact]
        public void DeveCriarCurso()
        {
            // Arrange (Organização)
            const string nome = "Informática Básica";
            const double cargaHoraria = 80;
            const string publicoAlvo = "Estudantes";
            const double valorCurso = 950;

            // Act (Ação)
            var curso = new Curso(nome, cargaHoraria, publicoAlvo, valorCurso);

            // Assert
            Assert.Equal(nome, curso.Nome);
            Assert.Equal(cargaHoraria, curso.CargaHoraria);
            Assert.Equal(publicoAlvo, curso.PublicoAlvo);
            Assert.Equal(valorCurso, curso.ValorCurso);
        }
    }
}
