using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CursoOnline.DominioTest
{
    public class MeuPrimeiroTeste
    {
        [Fact(DisplayName = "Testar2")]
        public void DeveAsVariaveisTeremOMesmoValor()
        {
            // Organização
            var variavel1 = 1;
            var variavel2 = 1;

            // Ação

            // Assert
            Assert.True(variavel1 == variavel2);
        }
    }
}
