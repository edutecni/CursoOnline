using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CursoOnline.Dominio.Cursos;
using ExpectedObjects;

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
            // Lembrando que os nomes dos campos do objeto anônimo abaixo devem estar iguais aos do opjeto que será comparado.
            var cursoEsperado = new
            {
                Nome = "Informática Básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                ValorCurso = (double)950
            };

            // Act (Ação)
            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.ValorCurso);

            // Assert
            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }

        // Quando se utiliza o Decorator Theory, cada um dos InlineDatas serão executados uma vez.
        // Nesse caso um será executado passando uma string vazia, e o outro passando string nula.
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerUmNomeVazio(string nomeInvalid)
        {
            var cursoEsperado = new
            {
                Nome = nomeInvalid,
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                ValorCurso = (double)950
            };

            // O Lambda abaixo do "Assert.Throws<ArgumentException>(()..." significa que ele expera uma Função
            var message = Assert.Throws<ArgumentException>(() =>
            new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.ValorCurso)).Message;

            Assert.Equal("Nome inválido!", message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmaCargaHorariaMenorQue1(double cargaHorariaInvalida)
        {
            var cursoEsperado = new
            {
                Nome = "Informática Básica",
                CargaHoraria = cargaHorariaInvalida,
                PublicoAlvo = PublicoAlvo.Estudante,
                ValorCurso = (double)950
            };

            var message = Assert.Throws<ArgumentException>(() =>
            new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.ValorCurso)).Message;

            Assert.Equal("Carga horária menor que 1!", message);

        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmValorMenorQue1(double valorCursoInvalido)
        {
            var cursoEsperado = new
            {
                Nome = "Informática Básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoAlvo.Estudante,
                ValorCurso = valorCursoInvalido
            };

            var message = Assert.Throws<ArgumentException>(() =>
            new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.ValorCurso)).Message;

            Assert.Equal("Valor do curso menor que 1!", message);

        }

    }
    
}
