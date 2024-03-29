﻿using System;

namespace DotnetCsharpClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var IndiceAluno = 0;
            string InfoUsuario = ObterInfoUsuario();

            while (InfoUsuario.ToUpper() != "X")
            {
                switch (InfoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno:");
                        var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno:");
                        
                        if(decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Informar nota em valor decimal");
                        }

                        alunos[IndiceAluno] = aluno;
                        IndiceAluno++;
                        break;
                    case "2":
                        foreach(var a in alunos)
                        {
                            if(!string.IsNullOrEmpty(a.Nome))
                            {
                            Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Nota}");
                            }
                        } 
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var numAlunos = 0;
                        for( int i = 0; i < alunos.Length; i++)
                        {
                            if(!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                numAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / numAlunos;
                        Conceito conceitoGeral;

                        if(mediaGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if(mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if(mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if(mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"Média Geral: {mediaGeral} - Conceito: {conceitoGeral}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                InfoUsuario = ObterInfoUsuario();
            }
        }

        private static string ObterInfoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1. Inserir novo aluno");
            Console.WriteLine("2. Listar alunos");
            Console.WriteLine("3. Calcular média geral");
            Console.WriteLine("X. Sair");
            Console.WriteLine();

            string InfoUsuario = Console.ReadLine();
            Console.WriteLine();
            return InfoUsuario;
        }
    }
}