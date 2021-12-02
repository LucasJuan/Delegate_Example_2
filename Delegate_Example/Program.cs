using System;
using System.Text;

namespace Delegate_Example
{
    class Program
    {
        public delegate void MyDelegate(string msg);
        public delegate TResult Func<T1, T2, out TResult>(T1 arg, T2 arg2);
        public static decimal val = 0, val2 = 0;
        static void Main(string[] args)
        {

            StringBuilder menu = new StringBuilder();
            //Criando o menu
            menu.AppendLine("\n------------------------");
            menu.AppendLine("1 UPPERCASE (Delegate)");
            menu.AppendLine("2 Somar dois valores (Func Delegate)");
            menu.AppendLine("3 Somar dois valores (Events Handler)");
            menu.AppendLine("4 Exit");
            menu.AppendLine("------------------------");
            string valInput = "";
            do
            {
                Console.WriteLine(menu.ToString());
                valInput = Console.ReadLine();
                ;

                switch (valInput)
                {
                    case "1":
                        MyDelegate del = UpperCase;
                        string texto = Console.ReadLine();
                        del(texto);
                        break;
                    case "2":
                        Func<decimal, decimal, decimal> add = Somar;
                        receberDados();
                        decimal result = add(val, val2);
                        Console.WriteLine("Valor da soma: " + result);
                        break;
                    case "3":
                        ClasseLogica cl = new ClasseLogica();
                        cl.ProcessCompleted += cl_ProcessCompleted;
                        cl.StartProcess();

                        break;
                    case "4":
                        valInput = "N";
                        break;
                    default:
                        break;
                }
            } while (valInput != "N");

        }

        private static decimal Somar(decimal arg, decimal arg2)
        {
            return arg + arg2;
        }

        private static void UpperCase(string msg)
        {
            if (string.IsNullOrEmpty(msg))
                Console.WriteLine("O valor não pode ser nulo ou vazio");
            else
                Console.WriteLine("String: " + msg.ToUpper());
        }
        public static void receberDados()
        {
            bool a = false, b = false;
            Console.WriteLine("Digite o valor 1");
            string arg = Console.ReadLine();
            while (a == false)
            {
                if (!decimal.TryParse(arg, out val))
                {
                    Console.WriteLine("Por favor digite um numero inteiro ou decimal separado por ponto");
                    a = false;
                    Console.WriteLine("Digite o valor 1");
                    arg = Console.ReadLine();
                }
                else
                    a = true;
            }
            Console.WriteLine("Digite o valor 2");
            string arg2 = Console.ReadLine();
            while (b == false)
            {

                if (!decimal.TryParse(arg2, out val2))
                {
                    Console.WriteLine("Por favor digite um numero inteiro ou decimal separado por ponto");
                    b = false;
                    Console.WriteLine("Digite o valor 2");
                    arg2 = Console.ReadLine();
                }
                else
                    b = true;

            }
        }
        // event handler
        public static void cl_ProcessCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Processo completo!");
        }

    }
    public class ClasseLogica
    {
        public event EventHandler ProcessCompleted; // event

        public void StartProcess()
        {
            Console.WriteLine("Processo Iniciado!");
            // some code here..
            OnProcessCompleted(EventArgs.Empty);
        }

        protected virtual void OnProcessCompleted(EventArgs e)
        {
            ProcessCompleted?.Invoke(this, e);
        }
    }
}
