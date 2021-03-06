using Bogus;
using CursoOnline.Dominio.Cursos;
using CursoOnline.DominioTest._Builders;
using CursoOnline.DominioTest._Util;
using ExpectedObjects;
using System;
using Xunit;
using Xunit.Abstractions;

namespace CursoOnline.DominioTest.Cursos
{
    public class CursoTest : IDisposable
    {
        // "Eu, enquanto administrador quero criar e editar curso parq que sejam abertas instrções para o mesmo."

        // Critério de aceite

        // - Criar um curso com, nome carga hotária, publico alvo e valor do curso.
        // - As opções para público alvo são: Estudante, Universitário, Empregado e Empregador.
        // - Todos os campos do curso são obrigatório.
        // - Curso deve ter uma descrição

        private readonly ITestOutputHelper _ouput;
        private readonly string _nome;
        private readonly double _cargaHoraria;
        private readonly PublicoAlvo _publicoAlvo;
        private readonly double _valor;
        private readonly string _descricao;

        // Setup
        // Setup é executado no construtor para prepara o teste e será executado sempre a cada teste
        public CursoTest(ITestOutputHelper output)
        {
            _ouput = output;
            _ouput.WriteLine("Construtor sendo executado");
            var faker = new Faker();

            _nome = faker.Random.Words();
            _cargaHoraria = faker.Random.Double(50, 100);
            _publicoAlvo = PublicoAlvo.Estudante;
            _valor = faker.Random.Double(100, 1000);
            _descricao = faker.Lorem.Paragraph();

            
            _ouput.WriteLine($"Doube: {faker.Random.Double(1,100)}");
            _ouput.WriteLine($"Company: {faker.Company.CompanyName()}");
            _ouput.WriteLine($"PersonEmail: {faker.Person.Email}");
            _ouput.WriteLine($"Descricao: {faker.Lorem.Paragraph()}");

        }

        // Cleanup
        // Cleanup é executado depois de cada teste e serve para limpar os testes
        // Tem de ser feito dentro do Dispose
        public void Dispose()
        {
            _ouput.WriteLine("Dispose sendo executado");
        }

        [Fact]
        public void DeveCriarCurso()
        {
            // Arrange (Organização)
            // Lembrando que os nomes dos campos do objeto anônimo abaixo devem estar iguais aos do opjeto que será comparado.
            var cursoEsperado = new
            {
                Nome            = _nome,
                CargaHoraria    = _cargaHoraria,
                PublicoAlvo     = _publicoAlvo,
                ValorCurso      = _valor,
                Descricao       = _descricao
            };

            // Act (Ação)
            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.Descricao, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.ValorCurso);

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

            // O Lambda abaixo do "Assert.Throws<ArgumentException>(()..." significa que ele expera uma Função
            Assert.Throws<ArgumentException>(() =>
            CursoBuilder.Novo().ComNome(nomeInvalid).Build())
                .ComMensagem("Nome inválido!");

            
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmaCargaHorariaMenorQue1(double cargaHorariaInvalida)
        {

            Assert.Throws<ArgumentException>(() =>
            CursoBuilder.Novo().ComCargaHoraria(cargaHorariaInvalida).Build())
                .ComMensagem("Carga horária menor que 1!");

        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmValorMenorQue1(double valorCursoInvalido)
        {

            Assert.Throws<ArgumentException>(() =>
            CursoBuilder.Novo().ComValor(valorCursoInvalido).Build())
                .ComMensagem("Valor do curso menor que 1!");

        }        


    }
    
}
