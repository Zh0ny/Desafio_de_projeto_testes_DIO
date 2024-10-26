using Calculadora.Models;
using Xunit;
namespace CalculadoraTestes;

public class CalculadoraTestes
{
    private CalculadoraMetodos _calculadora;
    public CalculadoraTestes()
    {
        _calculadora = new CalculadoraMetodos("25/10/2024");
    }
    [Theory]
    [InlineData(10, 20, 30)]
    [InlineData(20, 10, 30)]
    [InlineData(30, 20, 50)]
    [InlineData(50, 10, 60)]
    public void Dado2Numeros_QuandoSomado_RetornaSomaCorreta(double val1, double val2, double resultadoEsperado){
        //Arrange
        //Act
        double resultado = _calculadora.Somar(val1, val2);
        //Assert
        Assert.Equal(resultadoEsperado, resultado);
    }
    [Theory]
    [InlineData(10, 20, -10)]
    [InlineData(20, 10, 10)]
    [InlineData(30, 20, 10)]
    [InlineData(50, 10, 40)]
    public void Dado2Numeros_QuandoSubtraido_RetornaSubtracaoCorreta(double val1, double val2, double resultadoEsperado){
        //Arrange
        //Act
        double resultado = _calculadora.Subtrair(val1, val2);
        //Assert
        Assert.Equal(resultadoEsperado, resultado);
    }
    [Theory]
    [InlineData(10, 20, 200)]
    [InlineData(20, 10, 200)]
    [InlineData(30, 20, 600)]
    [InlineData(50, 10, 500)]
    public void Dado2Numeros_QuandoMultiplicado_RetornaMultiplicacaoCorreta(double val1, double val2, double resultadoEsperado){
        //Arrange
        //Act
        double resultado = _calculadora.Multiplicar(val1, val2);
        //Assert
        Assert.Equal(resultadoEsperado, resultado);
    }
    [Theory]
    [InlineData(10, 20, 0.5f)]
    [InlineData(20, 10, 2)]
    [InlineData(30, 20, 1.5f)]
    [InlineData(50, 10, 5)]
    public void Dado2Numeros_QuandoDividido_RetornaDivisaoCorreta(double val1, double val2, double resultadoEsperado){
        //Arrange
        //Act
        double resultado = _calculadora.Dividir(val1, val2);
        //Assert
        Assert.Equal(resultadoEsperado, resultado);
    }

    [Theory]
    [InlineData(10, 0)]
    [InlineData(20, 0)]
    [InlineData(30, 0)]
    [InlineData(50, 0)]
    public void Dado2Numeros_QuandoDivididoPor0_RetornaExcecao(double val1, double val2){
        //Arrange
        //Act
        //Assert
        Assert.Throws<DivideByZeroException>(() =>_calculadora.Dividir(val1, val2));
    }
    [Fact]
    public void QuandoSolicitadoHistorico_RetornaLista(){
        //Arrange
        //Act
        _calculadora.Somar(2,4);
        _calculadora.Somar(5,6);
        _calculadora.Somar(1,7);
        _calculadora.Somar(8,8);
        var resultado = _calculadora.ObterHistorico();
        //Assert
        Assert.NotEmpty(resultado);
        Assert.Equal(3, resultado.Count);
    }
}