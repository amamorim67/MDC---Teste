using System;

public class MDC
{
    public static void Main()
    {
        /***** ESTE MÉTODO NÃO DEVE SER ALTERADO.

        Leia atentamente as instruções e escreva um programa para calcular o MDC de dois números positivos A e B.
        A saída do console deverá apresentar os números esperados.
        Boas práticas também serão avaliadas. :)

        O algoritmo para calcular o MDC de dois números positivos A e B consiste em:
        - Identificar o menor número entre A e B, supondo que B < A.
        - Se B é igual a zero, então o MDC é igual a A.
        - Caso contrário o MDC entre A e B será o mesmo que o MDC de B e (A % B), onde (A % B) representa o resto de A quando dividido por B. Para calcular o MDC de B e (A % B) podemos aplicar o mesmo método.

        *****/

        // Entrada: Cada uma das linhas contém uma string representando os números A e B separados por um espaço:
        //Console.WriteLine(Process("10"));
        Console.WriteLine(Process("0 1"));
        Console.WriteLine(Process("1 1000"));
        Console.WriteLine(Process("3 9"));
        Console.WriteLine(Process("123 456"));
        Console.WriteLine(Process("340 728"));
        Console.WriteLine(Process("12 18"));
        Console.WriteLine(Process("200 456"));
        Console.WriteLine(Process("66 121"));
        Console.WriteLine(Process("231 825"));
        Console.WriteLine(Process("90 180"));

        /***** Saída:
        Para cada linha que contém os dois números inteiros A e B, imprima o MDC de A e B. Saída esperada:
        1
        1
        3
        3
        4
        6
        8
        11
        33
        90
        *****/
    }

    public static string Process(string input)
    {
        // Vamos começar!

        // Leitura dos 2 números que devem ser submetidos ao cálculo do MDC
        string[] numerosString = input.Split(' ');

        int[] numeros = new int[2] { Int16.Parse(numerosString[0]), Int16.Parse(numerosString[1]) };

        //-------------------------------------------
        // Cálculo do MDC
        //-------------------------------------------

        // Lista de números primos - utilizados na apuração do MDC
        double[] numerosPrimos = new double[15] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47 };
        int proximoNumeroPrimo = 0;
        double divisorValido = 1;

        // Apuração do MDC
        while (numeros[0] != 1 && numeros[1] != 1)
        {

            double resultado1 = numeros[0] / numerosPrimos[proximoNumeroPrimo];
            double resultado2 = numeros[1] / numerosPrimos[proximoNumeroPrimo];
            double resultadoTruncado1 = Math.Truncate(resultado1);
            double resultadoTruncado2 = Math.Truncate(resultado2);

            // Reduz 1º número
            if ((resultadoTruncado1 == resultado1))
            {
                numeros[0] = (int)resultadoTruncado1;
            }

            // Reduz 2º número
            if ((resultadoTruncado2 == resultado2))
            {
                numeros[1] = (int)resultadoTruncado2;
            }

            // Registrar divisor válido
            if ((resultadoTruncado1 == resultado1) && (resultadoTruncado2 == resultado2))
            {
                divisorValido = divisorValido * numerosPrimos[proximoNumeroPrimo];
            }

            // Próximo número primo - sempre que nenhum número for divisível pelo primo
            if ((resultadoTruncado1 != resultado1) && (resultadoTruncado2 != resultado2))
            {
                proximoNumeroPrimo++;
            }

        }

        Console.WriteLine("MDC: de " + numerosString[0] + " e " + numerosString[1] + " = " + divisorValido);
        return "";
    }

}